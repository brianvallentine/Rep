using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1 : QueryBasis<R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX
            INTO :APOLICOB-IMP-SEGURADA-IX,
            :APOLICOB-PRM-TARIFARIO-IX
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA = :WS-RAMO
            AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA
            AND COD_COBERTURA = :APOLICOB-COD-COBERTURA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA = '{this.WS_RAMO}'
											AND MODALI_COBERTURA = '{this.WS_V0APOL_MODALIDA}'
											AND COD_COBERTURA = '{this.APOLICOB_COD_COBERTURA}'
											WITH UR";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string WS_V0APOL_MODALIDA { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WS_RAMO { get; set; }

        public static R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1 Execute(R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1 r2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1)
        {
            var ths = r2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}