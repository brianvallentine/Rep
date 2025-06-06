using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0965B
{
    public class R2200_00_SELECT_SI155_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_SI155_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VLR_CORRECAO ,
            VLR_MULTA
            INTO
            :SI155-VLR-CORRECAO ,
            :SI155-VLR-MULTA
            FROM
            SEGUROS.SI_MOV_HABIT_PAR
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :WHOST-MAX-OCORR
            AND COD_OPERACAO IN (1181, 1182, 1183, 1184)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLR_CORRECAO 
							,
											VLR_MULTA
											FROM
											SEGUROS.SI_MOV_HABIT_PAR
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.WHOST_MAX_OCORR}'
											AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184)";

            return query;
        }
        public string SI155_VLR_CORRECAO { get; set; }
        public string SI155_VLR_MULTA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string WHOST_MAX_OCORR { get; set; }

        public static R2200_00_SELECT_SI155_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_SI155_DB_SELECT_1_Query1 r2200_00_SELECT_SI155_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_SI155_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_SI155_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_SI155_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI155_VLR_CORRECAO = result[i++].Value?.ToString();
            dta.SI155_VLR_MULTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}