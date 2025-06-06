using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODUNIMO,
            PCCOMCOR,
            PCIOCC
            INTO :V1BILC-CODUNIMO,
            :V1BILC-PCCOMCOR,
            :V1BILC-PCIOCC
            FROM SEGUROS.V0BILHETE_COBER
            WHERE COD_EMPRESA = 0
            AND RAMOFR = :V1BILC-RAMOFR
            AND MODALIFR = :V1BILC-MODALIFR
            AND COD_OPCAO = :V1BILC-OPCAO
            AND CODPRODU = :V1BILC-CODPRODU
            AND PCCOMCOR > 0
            AND IDE_COBERTURA = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODUNIMO
							,
											PCCOMCOR
							,
											PCIOCC
											FROM SEGUROS.V0BILHETE_COBER
											WHERE COD_EMPRESA = 0
											AND RAMOFR = '{this.V1BILC_RAMOFR}'
											AND MODALIFR = '{this.V1BILC_MODALIFR}'
											AND COD_OPCAO = '{this.V1BILC_OPCAO}'
											AND CODPRODU = '{this.V1BILC_CODPRODU}'
											AND PCCOMCOR > 0
											AND IDE_COBERTURA = '1'";

            return query;
        }
        public string V1BILC_CODUNIMO { get; set; }
        public string V1BILC_PCCOMCOR { get; set; }
        public string V1BILC_PCIOCC { get; set; }
        public string V1BILC_MODALIFR { get; set; }
        public string V1BILC_CODPRODU { get; set; }
        public string V1BILC_RAMOFR { get; set; }
        public string V1BILC_OPCAO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1();
            var i = 0;
            dta.V1BILC_CODUNIMO = result[i++].Value?.ToString();
            dta.V1BILC_PCCOMCOR = result[i++].Value?.ToString();
            dta.V1BILC_PCIOCC = result[i++].Value?.ToString();
            return dta;
        }

    }
}