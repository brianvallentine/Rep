using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODUNIMO,
            PCCOMCOR,
            PCIOCC,
            VALMAX_COBERBAS
            INTO :V1BILC-CODUNIMO,
            :V1BILC-PCCOMCOR,
            :V1BILC-PCIOCC,
            :V1BILC-VALMAX
            FROM SEGUROS.V0BILHETE_COBER
            WHERE RAMOFR = :V1BILC-RAMOFR
            AND MODALIFR = :V1BILC-MODALIFR
            AND COD_OPCAO = :V1BILC-OPCAO
            AND PCCOMCOR > 0
            AND IDE_COBERTURA = '1'
            AND DTINIVIG <= :V0BILH-DTQITBCO
            AND DTTERVIG >= :V0BILH-DTQITBCO
            AND CODPRODU = :V1BILP-CODPRODU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODUNIMO
							,
											PCCOMCOR
							,
											PCIOCC
							,
											VALMAX_COBERBAS
											FROM SEGUROS.V0BILHETE_COBER
											WHERE RAMOFR = '{this.V1BILC_RAMOFR}'
											AND MODALIFR = '{this.V1BILC_MODALIFR}'
											AND COD_OPCAO = '{this.V1BILC_OPCAO}'
											AND PCCOMCOR > 0
											AND IDE_COBERTURA = '1'
											AND DTINIVIG <= '{this.V0BILH_DTQITBCO}'
											AND DTTERVIG >= '{this.V0BILH_DTQITBCO}'
											AND CODPRODU = '{this.V1BILP_CODPRODU}'";

            return query;
        }
        public string V1BILC_CODUNIMO { get; set; }
        public string V1BILC_PCCOMCOR { get; set; }
        public string V1BILC_PCIOCC { get; set; }
        public string V1BILC_VALMAX { get; set; }
        public string V1BILC_MODALIFR { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V1BILP_CODPRODU { get; set; }
        public string V1BILC_RAMOFR { get; set; }
        public string V1BILC_OPCAO { get; set; }

        public static R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1 Execute(R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1 r1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SEL_V0BILHETE_COBER2_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILC_CODUNIMO = result[i++].Value?.ToString();
            dta.V1BILC_PCCOMCOR = result[i++].Value?.ToString();
            dta.V1BILC_PCIOCC = result[i++].Value?.ToString();
            dta.V1BILC_VALMAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}