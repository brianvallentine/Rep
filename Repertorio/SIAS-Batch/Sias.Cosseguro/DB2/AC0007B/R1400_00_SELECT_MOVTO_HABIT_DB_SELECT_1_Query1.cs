using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ENDOSSO,
            VAL_PRM_CRED,
            VAL_REMUNERA,
            VAL_SUSEP
            INTO :MOVHBT-NUM-APOL,
            :MOVHBT-NUM-ENDS:VIND-NRENDOS,
            :MOVHBT-PRM-CRED,
            :MOVHBT-VAL-REMUN,
            :MOVHBT-VAL-SUSEP
            FROM SEGUROS.MOVIMENTO_HABIT
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NUM_ENDOSSO = :V0HISP-NRENDOS
            AND NUM_PARCELA = :V0HISP-NRPARCEL
            AND OCORR_HISTORICO = :V0HISP-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											VAL_PRM_CRED
							,
											VAL_REMUNERA
							,
											VAL_SUSEP
											FROM SEGUROS.MOVIMENTO_HABIT
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NUM_ENDOSSO = '{this.V0HISP_NRENDOS}'
											AND NUM_PARCELA = '{this.V0HISP_NRPARCEL}'
											AND OCORR_HISTORICO = '{this.V0HISP_OCORHIST}'";

            return query;
        }
        public string MOVHBT_NUM_APOL { get; set; }
        public string MOVHBT_NUM_ENDS { get; set; }
        public string VIND_NRENDOS { get; set; }
        public string MOVHBT_PRM_CRED { get; set; }
        public string MOVHBT_VAL_REMUN { get; set; }
        public string MOVHBT_VAL_SUSEP { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 r1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_MOVTO_HABIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVHBT_NUM_APOL = result[i++].Value?.ToString();
            dta.MOVHBT_NUM_ENDS = result[i++].Value?.ToString();
            dta.VIND_NRENDOS = string.IsNullOrWhiteSpace(dta.MOVHBT_NUM_ENDS) ? "-1" : "0";
            dta.MOVHBT_PRM_CRED = result[i++].Value?.ToString();
            dta.MOVHBT_VAL_REMUN = result[i++].Value?.ToString();
            dta.MOVHBT_VAL_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}