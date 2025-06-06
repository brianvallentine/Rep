using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
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
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-APOLICE
            AND NUM_PARCELA = :PROPOVA-OCORR-HISTORICO
            AND DATA_VENCIMENTO > :SISTEMAS-DATA-MOV-ABERTO
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
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_APOLICE}'
											AND NUM_PARCELA = '{this.PROPOVA_OCORR_HISTORICO}'
											AND DATA_VENCIMENTO > '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

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