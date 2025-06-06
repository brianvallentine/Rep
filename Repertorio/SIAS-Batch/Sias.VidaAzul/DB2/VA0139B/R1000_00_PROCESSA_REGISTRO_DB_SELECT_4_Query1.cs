using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDOSCOB ,
            ENDOSRES
            INTO :V0ENDO-NRENDOS-COB ,
            :V0ENDO-NRENDOS-RES
            FROM SEGUROS.V0NUMERO_AES
            WHERE COD_ORGAO = :V0APOL-ORGAO
            AND COD_RAMO = :V0APOL-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDOSCOB 
							,
											ENDOSRES
											FROM SEGUROS.V0NUMERO_AES
											WHERE COD_ORGAO = '{this.V0APOL_ORGAO}'
											AND COD_RAMO = '{this.V0APOL_RAMO}'";

            return query;
        }
        public string V0ENDO_NRENDOS_COB { get; set; }
        public string V0ENDO_NRENDOS_RES { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0APOL_RAMO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0ENDO_NRENDOS_COB = result[i++].Value?.ToString();
            dta.V0ENDO_NRENDOS_RES = result[i++].Value?.ToString();
            return dta;
        }

    }
}