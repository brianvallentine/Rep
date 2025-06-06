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
    public class M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1 : QueryBasis<M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGELOTE,
            DTLOTE,
            DTQITBCO,
            NRLOTE,
            NRSEQLOTE,
            CODPRODAZ
            INTO :PROPAZ-AGELOTE,
            :PROPAZ-DTLOTE,
            :PROPAZ-DTQITBCO,
            :PROPAZ-NRLOTE,
            :PROPAZ-NRSEQLOTE,
            :PROPAZ-CODPRODAZ
            FROM SEGUROS.V0PROPAZUL
            WHERE NRPROPAZ = :PROPAZ-NRPROPAZ
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGELOTE
							,
											DTLOTE
							,
											DTQITBCO
							,
											NRLOTE
							,
											NRSEQLOTE
							,
											CODPRODAZ
											FROM SEGUROS.V0PROPAZUL
											WHERE NRPROPAZ = '{this.PROPAZ_NRPROPAZ}'
											WITH UR";

            return query;
        }
        public string PROPAZ_AGELOTE { get; set; }
        public string PROPAZ_DTLOTE { get; set; }
        public string PROPAZ_DTQITBCO { get; set; }
        public string PROPAZ_NRLOTE { get; set; }
        public string PROPAZ_NRSEQLOTE { get; set; }
        public string PROPAZ_CODPRODAZ { get; set; }
        public string PROPAZ_NRPROPAZ { get; set; }

        public static M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1 Execute(M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1 m_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = m_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPAZ_AGELOTE = result[i++].Value?.ToString();
            dta.PROPAZ_DTLOTE = result[i++].Value?.ToString();
            dta.PROPAZ_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPAZ_NRLOTE = result[i++].Value?.ToString();
            dta.PROPAZ_NRSEQLOTE = result[i++].Value?.ToString();
            dta.PROPAZ_CODPRODAZ = result[i++].Value?.ToString();
            return dta;
        }

    }
}