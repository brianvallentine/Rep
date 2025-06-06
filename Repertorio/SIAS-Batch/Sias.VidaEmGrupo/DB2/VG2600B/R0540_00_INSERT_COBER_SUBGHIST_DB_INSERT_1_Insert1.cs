using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1 : QueryBasis<R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.VG_COBER_SUBG_HIST
            VALUES (:VGCOBSUB-NUM-APOLICE ,
            :VGCOBSUB-COD-SUBGRUPO ,
            :VGCOBSUB-DATA-INIVIGENCIA ,
            :VGCOBSUB-RAMO-COBERTURA ,
            :VGCOBSUB-COD-COBERTURA ,
            :VGCOBSUB-MODALI-COBERTURA ,
            :VGCOBSUB-IMP-SEGURADA-IX ,
            :VGCOBSUB-PRM-TARIFARIO-IX ,
            :VGCOBSUB-IMP-SEGURADA-VAR ,
            :VGCOBSUB-PRM-TARIFARIO-VAR ,
            :VGCOBSUB-PCT-COBERTURA ,
            :VGCOBSUB-FATOR-MULTIPLICA ,
            :VGCOBSUH-DATA-TERVIGENCIA ,
            :VGCOBSUB-TRATAMENTO-FATURA ,
            :VGCOBSUB-TRATAMENTO-PRMTOT ,
            :VGCOBSUB-COD-USUARIO ,
            CURRENT_TIMESTAMP ,
            :VGCOBSUB-VLR-LIM-MIN-COBER ,
            :VGCOBSUB-VLR-LIM-MAX-COBER )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_COBER_SUBG_HIST VALUES ({FieldThreatment(this.VGCOBSUB_NUM_APOLICE)} , {FieldThreatment(this.VGCOBSUB_COD_SUBGRUPO)} , {FieldThreatment(this.VGCOBSUB_DATA_INIVIGENCIA)} , {FieldThreatment(this.VGCOBSUB_RAMO_COBERTURA)} , {FieldThreatment(this.VGCOBSUB_COD_COBERTURA)} , {FieldThreatment(this.VGCOBSUB_MODALI_COBERTURA)} , {FieldThreatment(this.VGCOBSUB_IMP_SEGURADA_IX)} , {FieldThreatment(this.VGCOBSUB_PRM_TARIFARIO_IX)} , {FieldThreatment(this.VGCOBSUB_IMP_SEGURADA_VAR)} , {FieldThreatment(this.VGCOBSUB_PRM_TARIFARIO_VAR)} , {FieldThreatment(this.VGCOBSUB_PCT_COBERTURA)} , {FieldThreatment(this.VGCOBSUB_FATOR_MULTIPLICA)} , {FieldThreatment(this.VGCOBSUH_DATA_TERVIGENCIA)} , {FieldThreatment(this.VGCOBSUB_TRATAMENTO_FATURA)} , {FieldThreatment(this.VGCOBSUB_TRATAMENTO_PRMTOT)} , {FieldThreatment(this.VGCOBSUB_COD_USUARIO)} , CURRENT_TIMESTAMP , {FieldThreatment(this.VGCOBSUB_VLR_LIM_MIN_COBER)} , {FieldThreatment(this.VGCOBSUB_VLR_LIM_MAX_COBER)} )";

            return query;
        }
        public string VGCOBSUB_NUM_APOLICE { get; set; }
        public string VGCOBSUB_COD_SUBGRUPO { get; set; }
        public string VGCOBSUB_DATA_INIVIGENCIA { get; set; }
        public string VGCOBSUB_RAMO_COBERTURA { get; set; }
        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string VGCOBSUB_MODALI_COBERTURA { get; set; }
        public string VGCOBSUB_IMP_SEGURADA_IX { get; set; }
        public string VGCOBSUB_PRM_TARIFARIO_IX { get; set; }
        public string VGCOBSUB_IMP_SEGURADA_VAR { get; set; }
        public string VGCOBSUB_PRM_TARIFARIO_VAR { get; set; }
        public string VGCOBSUB_PCT_COBERTURA { get; set; }
        public string VGCOBSUB_FATOR_MULTIPLICA { get; set; }
        public string VGCOBSUH_DATA_TERVIGENCIA { get; set; }
        public string VGCOBSUB_TRATAMENTO_FATURA { get; set; }
        public string VGCOBSUB_TRATAMENTO_PRMTOT { get; set; }
        public string VGCOBSUB_COD_USUARIO { get; set; }
        public string VGCOBSUB_VLR_LIM_MIN_COBER { get; set; }
        public string VGCOBSUB_VLR_LIM_MAX_COBER { get; set; }

        public static void Execute(R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1 r0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1)
        {
            var ths = r0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}