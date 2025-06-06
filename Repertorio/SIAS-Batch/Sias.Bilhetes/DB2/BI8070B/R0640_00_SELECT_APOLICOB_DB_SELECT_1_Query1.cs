using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ITEM
            ,OCORR_HISTORICO
            ,RAMO_COBERTURA
            ,MODALI_COBERTURA
            ,COD_COBERTURA
            ,IMP_SEGURADA_IX
            ,PRM_TARIFARIO_IX
            ,IMP_SEGURADA_VAR
            ,PRM_TARIFARIO_VAR
            ,PCT_COBERTURA
            ,FATOR_MULTIPLICA
            INTO :APOLICOB-NUM-APOLICE
            ,:APOLICOB-NUM-ITEM
            ,:APOLICOB-OCORR-HISTORICO
            ,:APOLICOB-RAMO-COBERTURA
            ,:APOLICOB-MODALI-COBERTURA
            ,:APOLICOB-COD-COBERTURA
            ,:APOLICOB-IMP-SEGURADA-IX
            ,:APOLICOB-PRM-TARIFARIO-IX
            ,:APOLICOB-IMP-SEGURADA-VAR
            ,:APOLICOB-PRM-TARIFARIO-VAR
            ,:APOLICOB-PCT-COBERTURA
            ,:APOLICOB-FATOR-MULTIPLICA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO
            AND NUM_ITEM = 0
            AND COD_COBERTURA = 0
            AND PCT_COBERTURA = 100
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ITEM
											,OCORR_HISTORICO
											,RAMO_COBERTURA
											,MODALI_COBERTURA
											,COD_COBERTURA
											,IMP_SEGURADA_IX
											,PRM_TARIFARIO_IX
											,IMP_SEGURADA_VAR
											,PRM_TARIFARIO_VAR
											,PCT_COBERTURA
											,FATOR_MULTIPLICA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.WHOST_NUM_ENDOSSO}'
											AND NUM_ITEM = 0
											AND COD_COBERTURA = 0
											AND PCT_COBERTURA = 100
											WITH UR";

            return query;
        }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string APOLICOB_PCT_COBERTURA { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ENDOSSO { get; set; }

        public static R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLICOB_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PCT_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}