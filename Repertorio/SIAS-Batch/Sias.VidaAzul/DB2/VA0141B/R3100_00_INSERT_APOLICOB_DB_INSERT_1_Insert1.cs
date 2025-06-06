using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 : QueryBasis<R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.APOLICE_COBERTURAS
            (NUM_APOLICE
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
            ,TIMESTAMP
            ,SIT_REGISTRO)
            VALUES
            (:APOLICOB-NUM-APOLICE
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
            , CURRENT TIMESTAMP
            ,:APOLICOB-SIT-REGISTRO:VIND-NULL02)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,TIMESTAMP ,SIT_REGISTRO) VALUES ({FieldThreatment(this.APOLICOB_NUM_APOLICE)} ,{FieldThreatment(this.APOLICOB_NUM_ENDOSSO)} ,{FieldThreatment(this.APOLICOB_NUM_ITEM)} ,{FieldThreatment(this.APOLICOB_OCORR_HISTORICO)} ,{FieldThreatment(this.APOLICOB_RAMO_COBERTURA)} ,{FieldThreatment(this.APOLICOB_MODALI_COBERTURA)} ,{FieldThreatment(this.APOLICOB_COD_COBERTURA)} ,{FieldThreatment(this.APOLICOB_IMP_SEGURADA_IX)} ,{FieldThreatment(this.APOLICOB_PRM_TARIFARIO_IX)} ,{FieldThreatment(this.APOLICOB_IMP_SEGURADA_VAR)} ,{FieldThreatment(this.APOLICOB_PRM_TARIFARIO_VAR)} ,{FieldThreatment(this.APOLICOB_PCT_COBERTURA)} ,{FieldThreatment(this.APOLICOB_FATOR_MULTIPLICA)} ,{FieldThreatment(this.APOLICOB_DATA_INIVIGENCIA)} ,{FieldThreatment(this.APOLICOB_DATA_TERVIGENCIA)} , {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.APOLICOB_COD_EMPRESA))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.APOLICOB_SIT_REGISTRO))})";

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

        public static void Execute(R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1)
        {
            var ths = r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}