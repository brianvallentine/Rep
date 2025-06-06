using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU
            INTO :V1BILP-CODPRODU
            FROM SEGUROS.V0BILHETE_PLCOBER
            WHERE COD_EMPRESA = 0
            AND RAMOFR = :V0BILH-RAMO
            AND MODALIFR = 0
            AND COD_OPCAO = :V0BILH-OPCAO-COBER
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
											FROM SEGUROS.V0BILHETE_PLCOBER
											WHERE COD_EMPRESA = 0
											AND RAMOFR = '{this.V0BILH_RAMO}'
											AND MODALIFR = 0
											AND COD_OPCAO = '{this.V0BILH_OPCAO_COBER}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1BILP_CODPRODU { get; set; }
        public string V0BILH_OPCAO_COBER { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1BILP_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}