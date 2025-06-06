using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0095B
{
    public class R0010_10_LEITURA_DB_SELECT_1_Query1 : QueryBasis<R0010_10_LEITURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            INTO :V0SEG-FONTE
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND TIPO_SEGURADO = :MTIPO-SEGURADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string V0SEG_FONTE { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }

        public static R0010_10_LEITURA_DB_SELECT_1_Query1 Execute(R0010_10_LEITURA_DB_SELECT_1_Query1 r0010_10_LEITURA_DB_SELECT_1_Query1)
        {
            var ths = r0010_10_LEITURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0010_10_LEITURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0010_10_LEITURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEG_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}