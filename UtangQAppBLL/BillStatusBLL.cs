using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;
using static Dapper.SqlMapper;

namespace UtangQAppBLL
{
    public class BillStatusBLL : IBillStatusBLL
    {
        private readonly IBillStatus _billStatusDAL;
        public BillStatusBLL()
        {
            _billStatusDAL = new BillStatusDAL();
        }

        public void Create(BillStatusCreateDTO entity)
        {
            try
            {
                var billStatus = new BillStatus
                {
                    BillStatusDescription = entity.BillStatusDescription
                };
                _billStatusDAL.Create(billStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _billStatusDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BillStatusDTO Get(int id)
        {
            BillStatusDTO billStatusDTO = new BillStatusDTO();
            try
            {
                var billStatus = _billStatusDAL.Get(id);
                billStatusDTO.BillStatusID = billStatus.BillStatusID;
                billStatusDTO.BillStatusDescription = billStatus.BillStatusDescription;
                return billStatusDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(BillStatusDTO entity)
        {
            try
            {
                var billStatus = new BillStatus
                {
                    BillStatusID = entity.BillStatusID,
                    BillStatusDescription = entity.BillStatusDescription
                };
                _billStatusDAL.Update(billStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BillStatusDTO> GetAll()
        {
            List<BillStatusDTO> billStatusDTOs = new List<BillStatusDTO>();
            var billStatuses = _billStatusDAL.GetAll();
            foreach (var billStatus in billStatuses)
            {
                BillStatusDTO billStatusDTO = new BillStatusDTO
                {
                    BillStatusID = billStatus.BillStatusID,
                    BillStatusDescription = billStatus.BillStatusDescription
                };
                billStatusDTOs.Add(billStatusDTO);
            }
            return billStatusDTOs;
        }


    }
}
