using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1 : QueryBasis<R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX
            INTO :V0COBA-IMPINVPERM
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP)
            AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA
            AND COD_COBERTURA = 2
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA IN (81
							, 82
							, '{this.PARAMRAM_RAMO_AP}')
											AND MODALI_COBERTURA = '{this.WS_V0APOL_MODALIDA}'
											AND COD_COBERTURA = 2";

            return query;
        }
        public string V0COBA_IMPINVPERM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string WS_V0APOL_MODALIDA { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string PARAMRAM_RAMO_AP { get; set; }

        public static R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1 Execute(R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1 r0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1)
        {
            var ths = r0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0COBA_IMPINVPERM = result[i++].Value?.ToString();
            return dta;
        }

    }
}