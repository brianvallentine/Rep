using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            NRENDOS,
            NUM_ITEM,
            OCORHIST,
            RAMOFR,
            MODALIFR,
            COD_COBERTURA,
            IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX,
            FATOR_MULTIPLICA,
            DATA_INIVIGENCIA
            INTO
            :V0CBA-NUM-APOLICE,
            :V0CBA-NRENDOS,
            :V0CBA-NUM-ITEM,
            :V0CBA-OCOR-HIST,
            :V0CBA-RAMOFR,
            :V0CBA-MODALIFR,
            :V0CBA-CD-COBERTURA,
            :V0CBA-IMP-SEGURADA,
            :V0CBA-PR-TARIFARIO,
            :V0CBA-FATOR-MULTIP,
            :V0CBA-DTINIVIG
            FROM
            SEGUROS.V1COBERAPOL
            WHERE
            NUM_APOLICE = :V0CBA-NUM-APOLICE AND
            NRENDOS = 0 AND
            NUM_ITEM = :V0CBA-NUM-ITEM AND
            OCORHIST = :V0CBA-OCOR-HIST AND
            MODALIFR = 0 AND
            COD_COBERTURA = :V0CBA-CD-COBERTURA AND
            RAMOFR IN (:V0CBA-RAMOFR, 81)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NRENDOS
							,
											NUM_ITEM
							,
											OCORHIST
							,
											RAMOFR
							,
											MODALIFR
							,
											COD_COBERTURA
							,
											IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
							,
											FATOR_MULTIPLICA
							,
											DATA_INIVIGENCIA
											FROM
											SEGUROS.V1COBERAPOL
											WHERE
											NUM_APOLICE = '{this.V0CBA_NUM_APOLICE}' AND
											NRENDOS = 0 AND
											NUM_ITEM = '{this.V0CBA_NUM_ITEM}' AND
											OCORHIST = '{this.V0CBA_OCOR_HIST}' AND
											MODALIFR = 0 AND
											COD_COBERTURA = '{this.V0CBA_CD_COBERTURA}' AND
											RAMOFR IN ('{this.V0CBA_RAMOFR}'
							, 81)";

            return query;
        }
        public string V0CBA_NUM_APOLICE { get; set; }
        public string V0CBA_NRENDOS { get; set; }
        public string V0CBA_NUM_ITEM { get; set; }
        public string V0CBA_OCOR_HIST { get; set; }
        public string V0CBA_RAMOFR { get; set; }
        public string V0CBA_MODALIFR { get; set; }
        public string V0CBA_CD_COBERTURA { get; set; }
        public string V0CBA_IMP_SEGURADA { get; set; }
        public string V0CBA_PR_TARIFARIO { get; set; }
        public string V0CBA_FATOR_MULTIP { get; set; }
        public string V0CBA_DTINIVIG { get; set; }

        public static R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 Execute(R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 r0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = r0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CBA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0CBA_NRENDOS = result[i++].Value?.ToString();
            dta.V0CBA_NUM_ITEM = result[i++].Value?.ToString();
            dta.V0CBA_OCOR_HIST = result[i++].Value?.ToString();
            dta.V0CBA_RAMOFR = result[i++].Value?.ToString();
            dta.V0CBA_MODALIFR = result[i++].Value?.ToString();
            dta.V0CBA_CD_COBERTURA = result[i++].Value?.ToString();
            dta.V0CBA_IMP_SEGURADA = result[i++].Value?.ToString();
            dta.V0CBA_PR_TARIFARIO = result[i++].Value?.ToString();
            dta.V0CBA_FATOR_MULTIP = result[i++].Value?.ToString();
            dta.V0CBA_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}