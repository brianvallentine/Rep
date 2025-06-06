using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ENDOSSO,
            VAL_REMUNERA,
            VAL_SUSEP
            INTO :MOVHBT-NUM-APOL,
            :MOVHBT-NUM-ENDS:VIND-NUM-ENDS,
            :MOVHBT-VAL-REMUN,
            :MOVHBT-VAL-SUSEP
            FROM SEGUROS.MOVIMENTO_HABIT
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NUM_ENDOSSO = :V1HISP-NRENDOS
            AND NUM_PARCELA = :V1HISP-NRPARCEL
            AND OCORR_HISTORICO = 01
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											VAL_REMUNERA
							,
											VAL_SUSEP
											FROM SEGUROS.MOVIMENTO_HABIT
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NUM_ENDOSSO = '{this.V1HISP_NRENDOS}'
											AND NUM_PARCELA = '{this.V1HISP_NRPARCEL}'
											AND OCORR_HISTORICO = 01";

            return query;
        }
        public string MOVHBT_NUM_APOL { get; set; }
        public string MOVHBT_NUM_ENDS { get; set; }
        public string VIND_NUM_ENDS { get; set; }
        public string MOVHBT_VAL_REMUN { get; set; }
        public string MOVHBT_VAL_SUSEP { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 r1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVHBT_NUM_APOL = result[i++].Value?.ToString();
            dta.MOVHBT_NUM_ENDS = result[i++].Value?.ToString();
            dta.VIND_NUM_ENDS = string.IsNullOrWhiteSpace(dta.MOVHBT_NUM_ENDS) ? "-1" : "0";
            dta.MOVHBT_VAL_REMUN = result[i++].Value?.ToString();
            dta.MOVHBT_VAL_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}