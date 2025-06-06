using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0415B
{
    public class R050_SELECT_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<R050_SELECT_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            OCORR_HISTORICO,
            NUM_ITEM
            INTO :V0SEGV-SITUACAO,
            :V0SEGV-OCORHIST,
            :V0SEGV-NUMITEM
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_APOLICE = :V0PROP-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            AND NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											OCORR_HISTORICO
							,
											NUM_ITEM
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_APOLICE = '{this.V0PROP_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V0SEGV_SITUACAO { get; set; }
        public string V0SEGV_OCORHIST { get; set; }
        public string V0SEGV_NUMITEM { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_APOLICE { get; set; }

        public static R050_SELECT_SEGURAVG_DB_SELECT_1_Query1 Execute(R050_SELECT_SEGURAVG_DB_SELECT_1_Query1 r050_SELECT_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = r050_SELECT_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R050_SELECT_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R050_SELECT_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGV_SITUACAO = result[i++].Value?.ToString();
            dta.V0SEGV_OCORHIST = result[i++].Value?.ToString();
            dta.V0SEGV_NUMITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}