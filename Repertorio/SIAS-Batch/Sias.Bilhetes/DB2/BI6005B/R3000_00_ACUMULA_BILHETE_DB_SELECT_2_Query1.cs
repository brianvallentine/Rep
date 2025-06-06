using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCOAVISO ,
            AGEAVISO ,
            NRAVISO ,
            DATARCAP
            INTO :V1RCAC-BCOAVISO ,
            :V1RCAC-AGEAVISO ,
            :V1RCAC-NRAVISO ,
            :V1RCAC-DATARCAP
            FROM SEGUROS.V1RCAPCOMP
            WHERE FONTE = :V0RCAP-FONTE
            AND NRRCAP = :WHOST-NRRCAP
            AND NRRCAPCO = 0
            AND OPERACAO = :V0RCAP-OPERACAO
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCOAVISO 
							,
											AGEAVISO 
							,
											NRAVISO 
							,
											DATARCAP
											FROM SEGUROS.V1RCAPCOMP
											WHERE FONTE = '{this.V0RCAP_FONTE}'
											AND NRRCAP = '{this.WHOST_NRRCAP}'
											AND NRRCAPCO = 0
											AND OPERACAO = '{this.V0RCAP_OPERACAO}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1RCAC_BCOAVISO { get; set; }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }
        public string V1RCAC_DATARCAP { get; set; }
        public string V0RCAP_OPERACAO { get; set; }
        public string V0RCAP_FONTE { get; set; }
        public string WHOST_NRRCAP { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1RCAC_BCOAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_AGEAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_NRAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_DATARCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}