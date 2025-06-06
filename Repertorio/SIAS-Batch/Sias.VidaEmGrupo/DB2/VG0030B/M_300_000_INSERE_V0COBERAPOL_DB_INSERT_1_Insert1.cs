using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 : QueryBasis<M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0COBERAPOL
            VALUES (:VGNUM-APOLICE,
            :VGNRENDOS,
            :VGNUM-ITEM,
            :MAX-OCORR-HIST,
            :VGRAMOFR,
            :VGMODALIFR,
            :VGCOD-COBERTURA,
            :VGIMP-SEGURADA-IX,
            :VGPRM-TARIFARIO-IX,
            :VGIMP-SEGURADA-VAR,
            :PRM-TARIFARIO-VAR,
            :VGPCT-COBERTURA,
            :VGFATOR-MULTIPLICA,
            :VGDATA-INIVIGENCIA,
            :VGDATA-TERVIGENCIA,
            :MCOD-EMPRESA:WCOD-EMPRESA,
            CURRENT TIMESTAMP,
            :VGCOD-SITUACAO:VGCOD-SITUACAO-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERAPOL VALUES ({FieldThreatment(this.VGNUM_APOLICE)}, {FieldThreatment(this.VGNRENDOS)}, {FieldThreatment(this.VGNUM_ITEM)}, {FieldThreatment(this.MAX_OCORR_HIST)}, {FieldThreatment(this.VGRAMOFR)}, {FieldThreatment(this.VGMODALIFR)}, {FieldThreatment(this.VGCOD_COBERTURA)}, {FieldThreatment(this.VGIMP_SEGURADA_IX)}, {FieldThreatment(this.VGPRM_TARIFARIO_IX)}, {FieldThreatment(this.VGIMP_SEGURADA_VAR)}, {FieldThreatment(this.PRM_TARIFARIO_VAR)}, {FieldThreatment(this.VGPCT_COBERTURA)}, {FieldThreatment(this.VGFATOR_MULTIPLICA)}, {FieldThreatment(this.VGDATA_INIVIGENCIA)}, {FieldThreatment(this.VGDATA_TERVIGENCIA)},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.MCOD_EMPRESA))}, CURRENT TIMESTAMP,  {FieldThreatment((this.VGCOD_SITUACAO_I?.ToInt() == -1 ? null : this.VGCOD_SITUACAO))})";

            return query;
        }
        public string VGNUM_APOLICE { get; set; }
        public string VGNRENDOS { get; set; }
        public string VGNUM_ITEM { get; set; }
        public string MAX_OCORR_HIST { get; set; }
        public string VGRAMOFR { get; set; }
        public string VGMODALIFR { get; set; }
        public string VGCOD_COBERTURA { get; set; }
        public string VGIMP_SEGURADA_IX { get; set; }
        public string VGPRM_TARIFARIO_IX { get; set; }
        public string VGIMP_SEGURADA_VAR { get; set; }
        public string PRM_TARIFARIO_VAR { get; set; }
        public string VGPCT_COBERTURA { get; set; }
        public string VGFATOR_MULTIPLICA { get; set; }
        public string VGDATA_INIVIGENCIA { get; set; }
        public string VGDATA_TERVIGENCIA { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }
        public string VGCOD_SITUACAO { get; set; }
        public string VGCOD_SITUACAO_I { get; set; }

        public static void Execute(M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1)
        {
            var ths = m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}