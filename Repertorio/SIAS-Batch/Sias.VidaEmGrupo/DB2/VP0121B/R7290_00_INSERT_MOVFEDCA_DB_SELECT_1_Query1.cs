using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 : QueryBasis<R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :COMFEDCA-SITUACAO
            FROM SEGUROS.COMUNIC_FED_CAP_VA
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.COMUNIC_FED_CAP_VA
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string COMFEDCA_SITUACAO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 Execute(R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1)
        {
            var ths = r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COMFEDCA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}