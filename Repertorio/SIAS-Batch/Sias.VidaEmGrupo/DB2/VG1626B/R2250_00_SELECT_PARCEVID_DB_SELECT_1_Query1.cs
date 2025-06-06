using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO ,
            PREMIO_VG ,
            SIT_REGISTRO
            INTO :PARCEVID-DATA-VENCIMENTO ,
            :PARCEVID-PREMIO-VG ,
            :PARCEVID-SIT-REGISTRO
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :PROPOVA-NUM-PARCELA
            AND DATA_VENCIMENTO > :WHOST-DT-VENCIMENTO-PARC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO 
							,
											PREMIO_VG 
							,
											SIT_REGISTRO
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.PROPOVA_NUM_PARCELA}'
											AND DATA_VENCIMENTO > '{this.WHOST_DT_VENCIMENTO_PARC}'
											WITH UR";

            return query;
        }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string WHOST_DT_VENCIMENTO_PARC { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }

        public static R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PARCEVID_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}