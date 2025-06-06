using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1 : QueryBasis<M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOMPROPAZ
				SET SITUACAO = '2' ,
				COD_USUARIO =  '{this.USUARIO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRPROPAZ =  '{this.PROPAZ_NRPROPAZ}'
				AND AGELOTE =  '{this.PROPAZ_AGELOTE}'
				AND DTLOTE =  '{this.PROPAZ_DTLOTE}'
				AND NRLOTE =  '{this.PROPAZ_NRLOTE}'
				AND NRSEQLOTE =  '{this.PROPAZ_NRSEQLOTE}'
				AND TIPCOM = 'G'";

            return query;
        }
        public string USUARIO { get; set; }
        public string PROPAZ_NRSEQLOTE { get; set; }
        public string PROPAZ_NRPROPAZ { get; set; }
        public string PROPAZ_AGELOTE { get; set; }
        public string PROPAZ_DTLOTE { get; set; }
        public string PROPAZ_NRLOTE { get; set; }

        public static void Execute(M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1 m_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1)
        {
            var ths = m_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}