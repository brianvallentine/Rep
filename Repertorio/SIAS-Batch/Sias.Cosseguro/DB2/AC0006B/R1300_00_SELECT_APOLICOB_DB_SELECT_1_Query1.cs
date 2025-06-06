using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(IMP_SEGURADA_VAR),+0),
            VALUE(SUM(PRM_TARIFARIO_VAR),+0)
            INTO :APOLICOB-IMP-SEGURADA-VAR,
            :APOLICOB-PRM-TARIFARIO-VAR
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_ITEM = 0
            AND COD_COBERTURA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(IMP_SEGURADA_VAR)
							,+0)
							,
											VALUE(SUM(PRM_TARIFARIO_VAR)
							,+0)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_ITEM = 0
											AND COD_COBERTURA = 0";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}