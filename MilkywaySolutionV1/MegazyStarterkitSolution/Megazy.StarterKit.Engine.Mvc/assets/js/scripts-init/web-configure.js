var Config = Config || {};

Config.dxc = {
    mode: ((window.location.hostname === 'ocipa.developerinhouse.com' || window.location.hostname === 'rlpdsys.rlpd.go.th'
        || window.location.hostname === 'ocipasys.rlpd.go.th') ? 'production' : 'develop'),

    develop: {
        version: 'v1.0', // or v2.0, v2.1, v2.3
        client_id: 'rlpd-ocipa',
        response_type : "code",
        code_challenge_method : "S256",
        redirect_uri: "https://localhost:44380/dxc",
        endpoint : "https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth",//?client_id=${client_id}&response_type=${response_type}&code_challenge_method=${code_challenge_method}&code_challenge=${code_challenge}&scope=${scope}&redirect_uri=${redirect_uri}`,
        scope: 'offline_access dxc-data email profile nin',
        auth_uri: 'https://localhost:44380/linkageservice/auth',
        testcardid:'1310100131099' //'3441000106595'//
    },

    production: {
        version: 'v1.0', 
        client_id: 'rlpd-ocipa',
        response_type : "code",
        code_challenge_method : "S256",
        redirect_uri : "https://ocipa.developerinhouse.com/dxc",
        endpoint : "https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth",//?client_id=${client_id}&response_type=${response_type}&code_challenge_method=${code_challenge_method}&code_challenge=${code_challenge}&scope=${scope}&redirect_uri=${redirect_uri}`,
        scope: 'offline_access dxc-data email profile nin',
        auth_uri: 'https://ocipa.developerinhouse.com/linkageservice/auth',
        testcardid: ''
    }
};

Config.messageAlert = {
    name: '',
    url: ''
};