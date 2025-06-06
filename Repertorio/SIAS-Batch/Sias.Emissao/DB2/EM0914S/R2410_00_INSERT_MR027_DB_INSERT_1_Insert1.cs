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
    public class R2410_00_INSERT_MR027_DB_INSERT_1_Insert1 : QueryBasis<R2410_00_INSERT_MR027_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MR_APOL_SUB_COBER
            (NUM_APOLICE ,
            NUM_ENDOSSO ,
            COD_COBERTURA ,
            NUM_ITEM ,
            NUM_SUB_ITEM ,
            COD_RUBRICA ,
            COD_SUB_RUBRICA ,
            DTH_INI_VIGENCIA ,
            DTH_FIM_VIGENCIA ,
            VLR_IMP_SEGUR_IX ,
            VLR_IMP_SEGUR_VAR,
            NUM_TAXA_IS_COBER,
            VLR_TARIFARIO_IX ,
            VLR_TARIFARIO_VAR,
            PCT_FRANQUIA ,
            VLR_MIN_INDENIZ ,
            VLR_MAX_INDENIZ ,
            VLR_FRANQ_OBR_IX ,
            STA_REGISTRO ,
            DTH_CADASTRAMENTO)
            VALUES (:MR027-NUM-APOLICE,
            :MR027-NUM-ENDOSSO,
            :MR027-COD-COBERTURA,
            :MR027-NUM-ITEM,
            :MR027-NUM-SUB-ITEM,
            :MR027-COD-RUBRICA,
            :MR027-COD-SUB-RUBRICA,
            :MR027-DTH-INI-VIGENCIA,
            :MR027-DTH-FIM-VIGENCIA,
            :MR027-VLR-IMP-SEGUR-IX,
            :MR027-VLR-IMP-SEGUR-VAR,
            :MR027-NUM-TAXA-IS-COBER,
            :MR027-VLR-TARIFARIO-IX,
            :MR027-VLR-TARIFARIO-VAR,
            :MR027-PCT-FRANQUIA,
            :MR027-VLR-MIN-INDENIZ,
            :MR027-VLR-MAX-INDENIZ,
            :MR027-VLR-FRANQ-OBR-IX,
            :MR027-STA-REGISTRO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MR_APOL_SUB_COBER (NUM_APOLICE , NUM_ENDOSSO , COD_COBERTURA , NUM_ITEM , NUM_SUB_ITEM , COD_RUBRICA , COD_SUB_RUBRICA , DTH_INI_VIGENCIA , DTH_FIM_VIGENCIA , VLR_IMP_SEGUR_IX , VLR_IMP_SEGUR_VAR, NUM_TAXA_IS_COBER, VLR_TARIFARIO_IX , VLR_TARIFARIO_VAR, PCT_FRANQUIA , VLR_MIN_INDENIZ , VLR_MAX_INDENIZ , VLR_FRANQ_OBR_IX , STA_REGISTRO , DTH_CADASTRAMENTO) VALUES ({FieldThreatment(this.MR027_NUM_APOLICE)}, {FieldThreatment(this.MR027_NUM_ENDOSSO)}, {FieldThreatment(this.MR027_COD_COBERTURA)}, {FieldThreatment(this.MR027_NUM_ITEM)}, {FieldThreatment(this.MR027_NUM_SUB_ITEM)}, {FieldThreatment(this.MR027_COD_RUBRICA)}, {FieldThreatment(this.MR027_COD_SUB_RUBRICA)}, {FieldThreatment(this.MR027_DTH_INI_VIGENCIA)}, {FieldThreatment(this.MR027_DTH_FIM_VIGENCIA)}, {FieldThreatment(this.MR027_VLR_IMP_SEGUR_IX)}, {FieldThreatment(this.MR027_VLR_IMP_SEGUR_VAR)}, {FieldThreatment(this.MR027_NUM_TAXA_IS_COBER)}, {FieldThreatment(this.MR027_VLR_TARIFARIO_IX)}, {FieldThreatment(this.MR027_VLR_TARIFARIO_VAR)}, {FieldThreatment(this.MR027_PCT_FRANQUIA)}, {FieldThreatment(this.MR027_VLR_MIN_INDENIZ)}, {FieldThreatment(this.MR027_VLR_MAX_INDENIZ)}, {FieldThreatment(this.MR027_VLR_FRANQ_OBR_IX)}, {FieldThreatment(this.MR027_STA_REGISTRO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string MR027_NUM_APOLICE { get; set; }
        public string MR027_NUM_ENDOSSO { get; set; }
        public string MR027_COD_COBERTURA { get; set; }
        public string MR027_NUM_ITEM { get; set; }
        public string MR027_NUM_SUB_ITEM { get; set; }
        public string MR027_COD_RUBRICA { get; set; }
        public string MR027_COD_SUB_RUBRICA { get; set; }
        public string MR027_DTH_INI_VIGENCIA { get; set; }
        public string MR027_DTH_FIM_VIGENCIA { get; set; }
        public string MR027_VLR_IMP_SEGUR_IX { get; set; }
        public string MR027_VLR_IMP_SEGUR_VAR { get; set; }
        public string MR027_NUM_TAXA_IS_COBER { get; set; }
        public string MR027_VLR_TARIFARIO_IX { get; set; }
        public string MR027_VLR_TARIFARIO_VAR { get; set; }
        public string MR027_PCT_FRANQUIA { get; set; }
        public string MR027_VLR_MIN_INDENIZ { get; set; }
        public string MR027_VLR_MAX_INDENIZ { get; set; }
        public string MR027_VLR_FRANQ_OBR_IX { get; set; }
        public string MR027_STA_REGISTRO { get; set; }

        public static void Execute(R2410_00_INSERT_MR027_DB_INSERT_1_Insert1 r2410_00_INSERT_MR027_DB_INSERT_1_Insert1)
        {
            var ths = r2410_00_INSERT_MR027_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2410_00_INSERT_MR027_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}