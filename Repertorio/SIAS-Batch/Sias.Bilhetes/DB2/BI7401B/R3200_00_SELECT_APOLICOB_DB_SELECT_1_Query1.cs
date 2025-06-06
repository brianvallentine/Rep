using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
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
            ,DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            ,COD_EMPRESA
            ,SIT_REGISTRO
            INTO :APOLICOB-NUM-APOLICE
            ,:APOLICOB-NUM-ENDOSSO
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
            ,:APOLICOB-DATA-INIVIGENCIA
            ,:APOLICOB-DATA-TERVIGENCIA
            ,:APOLICOB-COD-EMPRESA:VIND-NULL01
            ,:APOLICOB-SIT-REGISTRO:VIND-NULL02
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
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
											,DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											,COD_EMPRESA
											,SIT_REGISTRO
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
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
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string APOLICOB_DATA_TERVIGENCIA { get; set; }
        public string APOLICOB_COD_EMPRESA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string APOLICOB_SIT_REGISTRO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }

        public static R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ENDOSSO = result[i++].Value?.ToString();
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
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.APOLICOB_COD_EMPRESA) ? "-1" : "0";
            dta.APOLICOB_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.APOLICOB_SIT_REGISTRO) ? "-1" : "0";
            return dta;
        }

    }
}