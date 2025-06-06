using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX,
            FATOR_MULTIPLICA
            INTO :APOLICOB-IMP-SEGURADA-AP,
            :APOLICOB-PRM-TARIFARIO-AP,
            :APOLICOB-FATOR-MULTIPLICA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND NUM_ENDOSSO = 1
            AND NUM_ITEM = 0
            AND OCORR_HISTORICO IN (0,1)
            AND RAMO_COBERTURA IN (81, 82, 37)
            AND MODALI_COBERTURA = 0
            ORDER BY TIMESTAMP DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
							,
											FATOR_MULTIPLICA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 1
											AND NUM_ITEM = 0
											AND OCORR_HISTORICO IN (0
							,1)
											AND RAMO_COBERTURA IN (81
							, 82
							, 37)
											AND MODALI_COBERTURA = 0
											ORDER BY TIMESTAMP DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_AP { get; set; }
        public string APOLICOB_PRM_TARIFARIO_AP { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_AP = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_AP = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}