using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1 : QueryBasis<M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.BENEFICIARIOS
            (NUM_APOLICE ,
            COD_SUBGRUPO ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            NUM_BENEFICIARIO ,
            NOME_BENEFICIARIO ,
            GRAU_PARENTESCO ,
            PCT_PART_BENEFICIA,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            COD_USUARIO ,
            COD_EMPRESA )
            VALUES (:NUM-APOLICE,
            :COD-SUBGRUPO,
            :MNUM-CERTIFICADO,
            :DAC-CERTIFICADO,
            :NUM-BENEFICIARIO,
            :NOME-BENEFICIARIO,
            :GRAU-PARENTESCO,
            :PCT-PART-BENEFICIA,
            :MDATA-MOVIMENTO,
            :DTTERVIG,
            :COD-USUARIO,
            :COD-EMPRESA:WCOD-EMPRESA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BENEFICIARIOS (NUM_APOLICE , COD_SUBGRUPO , NUM_CERTIFICADO , DAC_CERTIFICADO , NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA, DATA_INIVIGENCIA , DATA_TERVIGENCIA , COD_USUARIO , COD_EMPRESA ) VALUES ({FieldThreatment(this.NUM_APOLICE)}, {FieldThreatment(this.COD_SUBGRUPO)}, {FieldThreatment(this.MNUM_CERTIFICADO)}, {FieldThreatment(this.DAC_CERTIFICADO)}, {FieldThreatment(this.NUM_BENEFICIARIO)}, {FieldThreatment(this.NOME_BENEFICIARIO)}, {FieldThreatment(this.GRAU_PARENTESCO)}, {FieldThreatment(this.PCT_PART_BENEFICIA)}, {FieldThreatment(this.MDATA_MOVIMENTO)}, {FieldThreatment(this.DTTERVIG)}, {FieldThreatment(this.COD_USUARIO)},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.COD_EMPRESA))})";

            return query;
        }
        public string NUM_APOLICE { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string DAC_CERTIFICADO { get; set; }
        public string NUM_BENEFICIARIO { get; set; }
        public string NOME_BENEFICIARIO { get; set; }
        public string GRAU_PARENTESCO { get; set; }
        public string PCT_PART_BENEFICIA { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string DTTERVIG { get; set; }
        public string COD_USUARIO { get; set; }
        public string COD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }

        public static void Execute(M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1 m_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1)
        {
            var ths = m_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}