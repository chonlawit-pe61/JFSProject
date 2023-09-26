// Begin การไกล่เกลี่ย
$(function () {
    var componentName = 'casecreditscoring';

    $('#modalScoring').on('show.bs.modal', function (event) {
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
            $('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            //console.log(frm);
            $.ajax({
                url: '/jfservices/getcasecreditscoring',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val(),
                    caseTypeID: $('#caseTypeID' + componentName).val()
                },
                beforeSend: function () { },
                success: function (data) {

                    console.log('-----');
                    console.log(data);

                    if (data.Data != null) {

                        var setTopicScore = 0;
                        var setTopicID = 0;

                        $.each(data.Data.CaseCreditScoringRows, function (key, value) {
                            //CharacteristicID

                            if (setTopicID != value.TopicID) {
                                setTopicID = value.TopicID;
                                setTopicScore += value.TotalScoreTopic;
                            }
                            $('input[name=chkScoringchoice]').filter('#chkScoringchoice-' + value.ChoiceID).iCheck('check');
                        });

                        $('.total-creditscore').text(setTopicScore);
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();

                    }


                    //$('input:radio[name=rdoProposerType]').filter('#rdoProposerType' + caseProject.ProposerTypeID).iCheck('check');


                }
                , error: function (err) {
                    console.log(err);
                }
            });



        } else { console.log('default') }


        //var button = $(event.relatedTarget)
        //var modal = $(this)
    })



    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });




    function setTotalScoreByTopic(dataSet) {

        var totalScore = dataSet.topicScore;

        var isChecked = $('.js--chkgrouptopic-' + dataSet.topicID + ':checked');

        console.log("----isChecked---");
        console.log(isChecked.length);

        if (isChecked.length > 0) {

            if (dataSet.isOnly == 1) {

                console.log("----isOnly---");
                console.log(dataSet.isOnly);


                if (dataSet.currentScoreByTopic == 0) {

                    console.log("----currentScoreByTopic---");
                    console.log(dataSet.currentScoreByTopic);

                    totalScore = (dataSet.currentScoreByTopic + dataSet.topicScore);



                }

            }

        } else {

            totalScore = 0;
        }

        return totalScore;
    }

    $('#frm' + componentName)
        .off('keyup change ifChecked', '.js--chkScoringchoice')
        .on('keyup change ifChecked', '.js--chkScoringchoice', function (e) {

            var frm = $(this).closest('form');
            //var isChecked = $('.js--chkgrouptopic-1').is(':checked');
            var topicid = $(this).attr('data-topicid');

            var dataSet = {
                choiceID: $(this).attr('data-id'), //choiceID
                topicID: $(this).attr('data-topicid'), //topicID
                choiceScore: parseInt($(this).attr('data-score')), //choiceScore
                isOnly: parseInt($(this).attr('data-isonly')), //check isOnly
                topicScore: parseInt($(this).attr('data-topicScore')), //topicScore
                currentTotalScore: parseInt($('.total-creditscore:first').text()), //current Total Score
                currentScoreByTopic: parseInt($('#cresditscoreByTopic-' + topicid).text()), //current ScoreBy Topic
                //isChecked: isChecked
            }

            //total score

            var totalCreditScoreByTopic = setTotalScoreByTopic(dataSet);
            $('#cresditscoreByTopic-' + topicid).text(totalCreditScoreByTopic);
            var totalCreditScore = 0;
            $('div[name="cresditscoreByTopic"]').each(function () {
                totalCreditScore += parseInt($(this).text());
            });

            $('.total-creditscore').text(totalCreditScore);


            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })

        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var applicantID = parseInt($('#applicantID' + componentName).val());
            var caseId = parseInt($('#caseID' + componentName).val());
            var caseCreditScoringData = [];
            var CreditScoring = $('input[name="chkScoringchoice"]:checked');
            CreditScoring.each(function () {

                var topicid = parseInt($(this).data('topicid'));
                var totalScoreTopic = parseInt($('#cresditscoreByTopic-' + topicid).text());
                var choiceid = parseInt($(this).data('id'));

                //var passIsother = JSON.parse(isother.toLowerCase());
                caseCreditScoringData.push({
                    TopicID: topicid,
                    ChoiceID: choiceid,
                    TotalScoreTopic: totalScoreTopic
                });


            });
            $.ajax({
                url: '/jfservices/savecasecreditscoring',
                method: 'POST',
                data: {
                    req: caseCreditScoringData,
                    applicantID: applicantID,
                    caseID: caseId,
                    score: parseInt($('.total-creditscore:first').text()),
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        SWSuccess.fire();
                        $('#modalScoring').modal('hide');
                    } else {
                        SWError.fire();
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });
            //var frm = $(this).closest('form');
            //frm.find('.js--btsave' + componentName).show();
            //frm.find('.js--cancel').show();
        });

});
