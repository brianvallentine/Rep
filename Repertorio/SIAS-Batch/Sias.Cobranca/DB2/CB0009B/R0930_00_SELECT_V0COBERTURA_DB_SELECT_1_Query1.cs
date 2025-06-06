using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 : QueryBasis<R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPCAO ,
            DTINIVIG ,
            VLPRMTOT
            INTO :V0BCOB-CODOPCAO ,
            :V0BCOB-DTINIVIG ,
            :V0BCOB-VLPRMTOT:VIND-VLPRMTOT
            FROM SEGUROS.V0BILHETE_COBER
            WHERE COD_EMPRESA = 0
            AND RAMOFR = :V0BILH-RAMO
            AND MODALIFR = 0
            AND COD_OPCAO = :V0BILH-OPCOBER
            AND VLPRMTOT >= :WSHOST-VLPRMTOT1
            AND VLPRMTOT <= :WSHOST-VLPRMTOT2
            AND PCCOMCOR > 0
            AND IDE_COBERTURA = '1'
            AND DTINIVIG <= :V0BILH-DTQITBCO
            AND DTTERVIG >= :V0BILH-DTQITBCO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPCAO 
							,
											DTINIVIG 
							,
											VLPRMTOT
											FROM SEGUROS.V0BILHETE_COBER
											WHERE COD_EMPRESA = 0
											AND RAMOFR = '{this.V0BILH_RAMO}'
											AND MODALIFR = 0
											AND COD_OPCAO = '{this.V0BILH_OPCOBER}'
											AND VLPRMTOT >= '{this.WSHOST_VLPRMTOT1}'
											AND VLPRMTOT <= '{this.WSHOST_VLPRMTOT2}'
											AND PCCOMCOR > 0
											AND IDE_COBERTURA = '1'
											AND DTINIVIG <= '{this.V0BILH_DTQITBCO}'
											AND DTTERVIG >= '{this.V0BILH_DTQITBCO}'";

            return query;
        }
        public string V0BCOB_CODOPCAO { get; set; }
        public string V0BCOB_DTINIVIG { get; set; }
        public string V0BCOB_VLPRMTOT { get; set; }
        public string VIND_VLPRMTOT { get; set; }
        public string WSHOST_VLPRMTOT1 { get; set; }
        public string WSHOST_VLPRMTOT2 { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_OPCOBER { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 Execute(R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 r0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = r0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0930_00_SELECT_V0COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BCOB_CODOPCAO = result[i++].Value?.ToString();
            dta.V0BCOB_DTINIVIG = result[i++].Value?.ToString();
            dta.V0BCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.VIND_VLPRMTOT = string.IsNullOrWhiteSpace(dta.V0BCOB_VLPRMTOT) ? "-1" : "0";
            return dta;
        }

    }
}