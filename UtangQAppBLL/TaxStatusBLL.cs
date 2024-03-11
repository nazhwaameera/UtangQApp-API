using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;
using static Dapper.SqlMapper;

namespace UtangQAppBLL
{
    public class TaxStatusBLL : ITaxStatusBLL
    {
        private readonly ITaxStatus _taxStatusDAL;
        public TaxStatusBLL()
        {
            _taxStatusDAL = new TaxStatusDAL();
        }
        public void Create(TaxStatusCreateDTO entity)
        {
            try
            {
                var taxStatus = new TaxStatus
                {
                    TaxStatusDescription = entity.TaxStatusDescription
                };
                _taxStatusDAL.Create(taxStatus);
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
                _taxStatusDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaxStatusDTO Get(int id)
        {
            TaxStatusDTO taxStatusDTO = new TaxStatusDTO();
            try
            {
                var taxStatus = _taxStatusDAL.Get(id);
                taxStatusDTO.TaxStatusID = taxStatus.TaxStatusID;
                taxStatusDTO.TaxStatusDescription = taxStatus.TaxStatusDescription;
                return taxStatusDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TaxStatusDTO> GetAll()
        {
            List<TaxStatusDTO> taxStatusDTOs = new List<TaxStatusDTO>();
            var taxStatuses = _taxStatusDAL.GetAll();
            foreach (var taxStatus in taxStatuses)
            {
                TaxStatusDTO taxStatusDTO = new TaxStatusDTO
                {
                    TaxStatusID = taxStatus.TaxStatusID,
                    TaxStatusDescription = taxStatus.TaxStatusDescription
                };
                taxStatusDTOs.Add(taxStatusDTO);
            }
            return taxStatusDTOs;
        }

        public void Update(TaxStatusDTO entity)
        {
            try
            {
                var taxStatus = new TaxStatus
                {
                    TaxStatusID = entity.TaxStatusID,
                    TaxStatusDescription = entity.TaxStatusDescription
                };
                _taxStatusDAL.Update(taxStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
