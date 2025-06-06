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
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALADT
            INTO :V0COFE-VALADT
            FROM SEGUROS.V0COMISSAO_FENAE
            WHERE NUMBIL = :V0BILH-NUMBIL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALADT
											FROM SEGUROS.V0COMISSAO_FENAE
											WHERE NUMBIL = '{this.V0BILH_NUMBIL}'
											WITH UR";

            return query;
        }
        public string V0COFE_VALADT { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_8_Query1();
            var i = 0;
            dta.V0COFE_VALADT = result[i++].Value?.ToString();
            return dta;
        }

    }
}