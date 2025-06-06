using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0914S
{
    public class R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1 : QueryBasis<R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.APOLICE_CLAUSULAS
            (COD_EMPRESA,
            NUM_APOLICE,
            NUM_ENDOSSO,
            RAMO_COBERTURA,
            MODALI_COBERTURA,
            COD_COBERTURA ,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            NUM_ITEM ,
            COD_CLAUSULA ,
            TIPO_CLAUSULA ,
            LIMITE_INDENIZA_IX ,
            TIMESTAMP)
            VALUES (:APOLICLA-COD-EMPRESA,
            :APOLICLA-NUM-APOLICE,
            :APOLICLA-NUM-ENDOSSO,
            :APOLICLA-RAMO-COBERTURA,
            :APOLICLA-MODALI-COBERTURA,
            :APOLICLA-COD-COBERTURA ,
            :APOLICLA-DATA-INIVIGENCIA,
            :APOLICLA-DATA-TERVIGENCIA,
            :APOLICLA-NUM-ITEM ,
            :APOLICLA-COD-CLAUSULA ,
            :APOLICLA-TIPO-CLAUSULA ,
            :APOLICLA-LIMITE-INDENIZA-IX ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_CLAUSULAS (COD_EMPRESA, NUM_APOLICE, NUM_ENDOSSO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA , DATA_INIVIGENCIA, DATA_TERVIGENCIA, NUM_ITEM , COD_CLAUSULA , TIPO_CLAUSULA , LIMITE_INDENIZA_IX , TIMESTAMP) VALUES ({FieldThreatment(this.APOLICLA_COD_EMPRESA)}, {FieldThreatment(this.APOLICLA_NUM_APOLICE)}, {FieldThreatment(this.APOLICLA_NUM_ENDOSSO)}, {FieldThreatment(this.APOLICLA_RAMO_COBERTURA)}, {FieldThreatment(this.APOLICLA_MODALI_COBERTURA)}, {FieldThreatment(this.APOLICLA_COD_COBERTURA)} , {FieldThreatment(this.APOLICLA_DATA_INIVIGENCIA)}, {FieldThreatment(this.APOLICLA_DATA_TERVIGENCIA)}, {FieldThreatment(this.APOLICLA_NUM_ITEM)} , {FieldThreatment(this.APOLICLA_COD_CLAUSULA)} , {FieldThreatment(this.APOLICLA_TIPO_CLAUSULA)} , {FieldThreatment(this.APOLICLA_LIMITE_INDENIZA_IX)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string APOLICLA_COD_EMPRESA { get; set; }
        public string APOLICLA_NUM_APOLICE { get; set; }
        public string APOLICLA_NUM_ENDOSSO { get; set; }
        public string APOLICLA_RAMO_COBERTURA { get; set; }
        public string APOLICLA_MODALI_COBERTURA { get; set; }
        public string APOLICLA_COD_COBERTURA { get; set; }
        public string APOLICLA_DATA_INIVIGENCIA { get; set; }
        public string APOLICLA_DATA_TERVIGENCIA { get; set; }
        public string APOLICLA_NUM_ITEM { get; set; }
        public string APOLICLA_COD_CLAUSULA { get; set; }
        public string APOLICLA_TIPO_CLAUSULA { get; set; }
        public string APOLICLA_LIMITE_INDENIZA_IX { get; set; }

        public static void Execute(R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1 r2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1)
        {
            var ths = r2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}