using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1 : QueryBasis<R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            PRM_TARIFARIO_VAR
            INTO :APOLICOB-NUM-APOLICE,
            :APOLICOB-PRM-TARIFARIO-VAR
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND NUM_ENDOSSO = :RELATORI-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											PRM_TARIFARIO_VAR
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.RELATORI_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }

        public static R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1 Execute(R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1 r1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1)
        {
            var ths = r1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}