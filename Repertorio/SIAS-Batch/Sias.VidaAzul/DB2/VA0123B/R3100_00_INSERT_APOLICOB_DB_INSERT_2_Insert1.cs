using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1 : QueryBasis<R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.APOLICE_COBERTURAS
            (NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_ITEM,
            OCORR_HISTORICO,
            RAMO_COBERTURA,
            MODALI_COBERTURA,
            COD_COBERTURA,
            IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX,
            IMP_SEGURADA_VAR,
            PRM_TARIFARIO_VAR,
            PCT_COBERTURA,
            FATOR_MULTIPLICA,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            COD_EMPRESA,
            TIMESTAMP,
            SIT_REGISTRO)
            VALUES (:APOLICOB-NUM-APOLICE ,
            :APOLICOB-NUM-ENDOSSO ,
            :APOLICOB-NUM-ITEM ,
            :SEGURVGA-OCORR-HISTORICO1,
            :APOLICOB-RAMO-COBERTURA,
            :APOLICOB-MODALI-COBERTURA,
            :APOLICOB-COD-COBERTURA,
            :APOLICOB-IMP-SEGURADA-IX,
            :APOLICOB-PRM-TARIFARIO-IX,
            :APOLICOB-IMP-SEGURADA-VAR,
            :APOLICOB-PRM-TARIFARIO-VAR,
            :APOLICOB-PCT-COBERTURA,
            :APOLICOB-FATOR-MULTIPLICA,
            :SISTEMAS-DATA-MOV-ABERTO ,
            '9999-12-31' ,
            NULL,
            CURRENT TIMESTAMP,
            ' ' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, OCORR_HISTORICO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, IMP_SEGURADA_VAR, PRM_TARIFARIO_VAR, PCT_COBERTURA, FATOR_MULTIPLICA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, COD_EMPRESA, TIMESTAMP, SIT_REGISTRO) VALUES ({FieldThreatment(this.APOLICOB_NUM_APOLICE)} , {FieldThreatment(this.APOLICOB_NUM_ENDOSSO)} , {FieldThreatment(this.APOLICOB_NUM_ITEM)} , {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO1)}, {FieldThreatment(this.APOLICOB_RAMO_COBERTURA)}, {FieldThreatment(this.APOLICOB_MODALI_COBERTURA)}, {FieldThreatment(this.APOLICOB_COD_COBERTURA)}, {FieldThreatment(this.APOLICOB_IMP_SEGURADA_IX)}, {FieldThreatment(this.APOLICOB_PRM_TARIFARIO_IX)}, {FieldThreatment(this.APOLICOB_IMP_SEGURADA_VAR)}, {FieldThreatment(this.APOLICOB_PRM_TARIFARIO_VAR)}, {FieldThreatment(this.APOLICOB_PCT_COBERTURA)}, {FieldThreatment(this.APOLICOB_FATOR_MULTIPLICA)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , '9999-12-31' , NULL, CURRENT TIMESTAMP, ' ' )";

            return query;
        }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO1 { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string APOLICOB_PCT_COBERTURA { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1 r3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1)
        {
            var ths = r3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}