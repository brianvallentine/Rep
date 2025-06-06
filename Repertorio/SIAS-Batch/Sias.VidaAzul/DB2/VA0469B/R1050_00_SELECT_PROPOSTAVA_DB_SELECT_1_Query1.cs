using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            DATA_QUITACAO,
            SIT_REGISTRO,
            DTA_DECLINIO,
            COD_PRODUTO
            INTO :PROPOVA-COD-FONTE,
            :PROPOVA-DATA-QUITACAO,
            :PROPOVA-SIT-REGISTRO,
            :PROPOVA-DTA-DECLINIO:VIND-DTA-DECLINIO,
            :PROPOVA-COD-PRODUTO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											DATA_QUITACAO
							,
											SIT_REGISTRO
							,
											DTA_DECLINIO
							,
											COD_PRODUTO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_DTA_DECLINIO { get; set; }
        public string VIND_DTA_DECLINIO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 r1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_DTA_DECLINIO = result[i++].Value?.ToString();
            dta.VIND_DTA_DECLINIO = string.IsNullOrWhiteSpace(dta.PROPOVA_DTA_DECLINIO) ? "-1" : "0";
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}