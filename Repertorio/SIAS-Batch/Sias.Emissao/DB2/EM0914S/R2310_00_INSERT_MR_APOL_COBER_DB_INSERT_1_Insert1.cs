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
    public class R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1 : QueryBasis<R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MR_APOLICE_COBER
            (NUM_APOLICE,
            NUM_ENDOSSO,
            COD_COBERTURA,
            NUM_ITEM,
            RAMO_COBERTURA,
            MODALI_COBERTURA,
            DTH_INI_VIG_COBER,
            DTH_FIM_VIG_COBER,
            IMP_SEGURADA_IX,
            IMP_SEGURADA_VAR,
            TAXA_IS,
            PRM_TARIFARIO_IX,
            PRM_TARIFARIO_VAR,
            VAL_MIN_FRANQ_IX,
            PCT_FRANQUIA,
            SIT_REGISTRO,
            DTH_TIMESTAMP,
            COD_EMPRESA)
            VALUES (:MRAPOCOB-NUM-APOLICE ,
            :MRAPOCOB-NUM-ENDOSSO ,
            :MRAPOCOB-COD-COBERTURA ,
            :MRAPOCOB-NUM-ITEM ,
            :MRAPOCOB-RAMO-COBERTURA ,
            :MRAPOCOB-MODALI-COBERTURA ,
            :MRAPOCOB-DTH-INI-VIG-COBER,
            :MRAPOCOB-DTH-FIM-VIG-COBER,
            :MRAPOCOB-IMP-SEGURADA-IX ,
            :MRAPOCOB-IMP-SEGURADA-VAR ,
            :MRAPOCOB-TAXA-IS ,
            :MRAPOCOB-PRM-TARIFARIO-IX ,
            :MRAPOCOB-PRM-TARIFARIO-VAR,
            :MRAPOCOB-VAL-MIN-FRANQ-IX ,
            :MRAPOCOB-PCT-FRANQUIA ,
            :MRAPOCOB-SIT-REGISTRO ,
            CURRENT TIMESTAMP ,
            :MRAPOCOB-COD-EMPRESA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MR_APOLICE_COBER (NUM_APOLICE, NUM_ENDOSSO, COD_COBERTURA, NUM_ITEM, RAMO_COBERTURA, MODALI_COBERTURA, DTH_INI_VIG_COBER, DTH_FIM_VIG_COBER, IMP_SEGURADA_IX, IMP_SEGURADA_VAR, TAXA_IS, PRM_TARIFARIO_IX, PRM_TARIFARIO_VAR, VAL_MIN_FRANQ_IX, PCT_FRANQUIA, SIT_REGISTRO, DTH_TIMESTAMP, COD_EMPRESA) VALUES ({FieldThreatment(this.MRAPOCOB_NUM_APOLICE)} , {FieldThreatment(this.MRAPOCOB_NUM_ENDOSSO)} , {FieldThreatment(this.MRAPOCOB_COD_COBERTURA)} , {FieldThreatment(this.MRAPOCOB_NUM_ITEM)} , {FieldThreatment(this.MRAPOCOB_RAMO_COBERTURA)} , {FieldThreatment(this.MRAPOCOB_MODALI_COBERTURA)} , {FieldThreatment(this.MRAPOCOB_DTH_INI_VIG_COBER)}, {FieldThreatment(this.MRAPOCOB_DTH_FIM_VIG_COBER)}, {FieldThreatment(this.MRAPOCOB_IMP_SEGURADA_IX)} , {FieldThreatment(this.MRAPOCOB_IMP_SEGURADA_VAR)} , {FieldThreatment(this.MRAPOCOB_TAXA_IS)} , {FieldThreatment(this.MRAPOCOB_PRM_TARIFARIO_IX)} , {FieldThreatment(this.MRAPOCOB_PRM_TARIFARIO_VAR)}, {FieldThreatment(this.MRAPOCOB_VAL_MIN_FRANQ_IX)} , {FieldThreatment(this.MRAPOCOB_PCT_FRANQUIA)} , {FieldThreatment(this.MRAPOCOB_SIT_REGISTRO)} , CURRENT TIMESTAMP , {FieldThreatment(this.MRAPOCOB_COD_EMPRESA)})";

            return query;
        }
        public string MRAPOCOB_NUM_APOLICE { get; set; }
        public string MRAPOCOB_NUM_ENDOSSO { get; set; }
        public string MRAPOCOB_COD_COBERTURA { get; set; }
        public string MRAPOCOB_NUM_ITEM { get; set; }
        public string MRAPOCOB_RAMO_COBERTURA { get; set; }
        public string MRAPOCOB_MODALI_COBERTURA { get; set; }
        public string MRAPOCOB_DTH_INI_VIG_COBER { get; set; }
        public string MRAPOCOB_DTH_FIM_VIG_COBER { get; set; }
        public string MRAPOCOB_IMP_SEGURADA_IX { get; set; }
        public string MRAPOCOB_IMP_SEGURADA_VAR { get; set; }
        public string MRAPOCOB_TAXA_IS { get; set; }
        public string MRAPOCOB_PRM_TARIFARIO_IX { get; set; }
        public string MRAPOCOB_PRM_TARIFARIO_VAR { get; set; }
        public string MRAPOCOB_VAL_MIN_FRANQ_IX { get; set; }
        public string MRAPOCOB_PCT_FRANQUIA { get; set; }
        public string MRAPOCOB_SIT_REGISTRO { get; set; }
        public string MRAPOCOB_COD_EMPRESA { get; set; }

        public static void Execute(R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1 r2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1)
        {
            var ths = r2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}