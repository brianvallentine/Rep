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
    public class R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1 : QueryBasis<R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_COBERTURA_IX),
            SUM(PRM_TARIFARIO_IX),
            SUM(VLPRMTOT)
            INTO :V1BILC-IMPSEG-IX,
            :V1BILC-PRMTAR-IX,
            :V1BILC-PRMTOTAL:VIND-PRMTOTAL
            FROM SEGUROS.V0BILHETE_COBER
            WHERE RAMOFR = :V1BILC-RAMOFR
            AND MODALIFR = :V1BILC-MODALIFR
            AND COD_OPCAO = :V1BILC-OPCAO
            AND DTINIVIG <= :V0BILH-DTQITBCO
            AND DTTERVIG >= :V0BILH-DTQITBCO
            AND CODPRODU = :V1BILC-CODPRODU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_COBERTURA_IX)
							,
											SUM(PRM_TARIFARIO_IX)
							,
											SUM(VLPRMTOT)
											FROM SEGUROS.V0BILHETE_COBER
											WHERE RAMOFR = '{this.V1BILC_RAMOFR}'
											AND MODALIFR = '{this.V1BILC_MODALIFR}'
											AND COD_OPCAO = '{this.V1BILC_OPCAO}'
											AND DTINIVIG <= '{this.V0BILH_DTQITBCO}'
											AND DTTERVIG >= '{this.V0BILH_DTQITBCO}'
											AND CODPRODU = '{this.V1BILC_CODPRODU}'";

            return query;
        }
        public string V1BILC_IMPSEG_IX { get; set; }
        public string V1BILC_PRMTAR_IX { get; set; }
        public string V1BILC_PRMTOTAL { get; set; }
        public string VIND_PRMTOTAL { get; set; }
        public string V1BILC_MODALIFR { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V1BILC_CODPRODU { get; set; }
        public string V1BILC_RAMOFR { get; set; }
        public string V1BILC_OPCAO { get; set; }

        public static R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1 Execute(R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1 r1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1)
        {
            var ths = r1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1005_00_SEL_V0BILHETE_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILC_IMPSEG_IX = result[i++].Value?.ToString();
            dta.V1BILC_PRMTAR_IX = result[i++].Value?.ToString();
            dta.V1BILC_PRMTOTAL = result[i++].Value?.ToString();
            dta.VIND_PRMTOTAL = string.IsNullOrWhiteSpace(dta.V1BILC_PRMTOTAL) ? "-1" : "0";
            return dta;
        }

    }
}