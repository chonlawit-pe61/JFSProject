using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class AddressService
    {

        public int InsertOrUpdateAddress(AddressRow data)
        {

            int id = 0;
            DalBase dal = new DalBase();
            AddressCollection_Base objAddress = new AddressCollection_Base(CSystems.ProcessID);
            AddressRow addressRow = objAddress.GetByPrimaryKey(data.AddressID);
            if (addressRow != null)
            {
                //update
                addressRow.Address1 = data.Address1;
                addressRow.HouseNo = data.HouseNo;
                addressRow.VillageNo = data.VillageNo;
                addressRow.Soi = data.Soi;
                addressRow.Street = data.Street;
                addressRow.ProvinceID = data.ProvinceID;
                addressRow.DisctrictID = data.DisctrictID;
                addressRow.SubdistrictID = data.SubdistrictID;
                addressRow.PostCode = data.PostCode;
                addressRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                objAddress.UpdateOnlyPlainText(addressRow);
                id = addressRow.AddressID;
            }
            else
            {

                //insert
                id = objAddress.InsertOnlyPlainText(new AddressRow
                {
                    Address1 = data.Address1,
                    HouseNo = data.HouseNo,
                    VillageNo = data.VillageNo,
                    Soi = data.Soi,
                    Street = data.Street,
                    ProvinceID = data.ProvinceID,
                    DisctrictID = data.DisctrictID,
                    SubdistrictID = data.SubdistrictID,
                    PostCode = data.PostCode,
                    ModifiedDate = dal.GetSqlNow(CSystems.ProcessID),
                    Createdate = dal.GetSqlNow(CSystems.ProcessID)
                });

            }
            objAddress.Dispose();
            return id;
        }


    }
}
