using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0806B
{
    public class R0020_00_PROCESSA_DB_INSERT_1_Insert1 : QueryBasis<R0020_00_PROCESSA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_FOLLOW_UP
            (NOM_ARQUIVO,
            SEQ_GERACAO,
            NUM_FITA_CEF,
            NUM_NOSSA_FITA,
            NUM_LANCAMENTO,
            COD_CONVENIO,
            NUM_CERTIFICADO,
            COD_BANCO,
            STA_PROCESSAMENTO,
            NUM_VERSAO_LAYOUT,
            REG_LANCAMENTO,
            COD_USUARIO,
            DTH_ATUALIZACAO)
            VALUES (:VGFOLLOW-NOM-ARQUIVO,
            :VGFOLLOW-SEQ-GERACAO,
            :VGFOLLOW-NUM-FITA-CEF,
            :VGFOLLOW-NUM-NOSSA-FITA,
            :VGFOLLOW-NUM-LANCAMENTO,
            :VGFOLLOW-COD-CONVENIO,
            :VGFOLLOW-NUM-CERTIFICADO,
            :VGFOLLOW-COD-BANCO,
            :VGFOLLOW-STA-PROCESSAMENTO,
            :VGFOLLOW-NUM-VERSAO-LAYOUT,
            :VGFOLLOW-REG-LANCAMENTO,
            :VGFOLLOW-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_FOLLOW_UP (NOM_ARQUIVO, SEQ_GERACAO, NUM_FITA_CEF, NUM_NOSSA_FITA, NUM_LANCAMENTO, COD_CONVENIO, NUM_CERTIFICADO, COD_BANCO, STA_PROCESSAMENTO, NUM_VERSAO_LAYOUT, REG_LANCAMENTO, COD_USUARIO, DTH_ATUALIZACAO) VALUES ({FieldThreatment(this.VGFOLLOW_NOM_ARQUIVO)}, {FieldThreatment(this.VGFOLLOW_SEQ_GERACAO)}, {FieldThreatment(this.VGFOLLOW_NUM_FITA_CEF)}, {FieldThreatment(this.VGFOLLOW_NUM_NOSSA_FITA)}, {FieldThreatment(this.VGFOLLOW_NUM_LANCAMENTO)}, {FieldThreatment(this.VGFOLLOW_COD_CONVENIO)}, {FieldThreatment(this.VGFOLLOW_NUM_CERTIFICADO)}, {FieldThreatment(this.VGFOLLOW_COD_BANCO)}, {FieldThreatment(this.VGFOLLOW_STA_PROCESSAMENTO)}, {FieldThreatment(this.VGFOLLOW_NUM_VERSAO_LAYOUT)}, {FieldThreatment(this.VGFOLLOW_REG_LANCAMENTO)}, {FieldThreatment(this.VGFOLLOW_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string VGFOLLOW_NOM_ARQUIVO { get; set; }
        public string VGFOLLOW_SEQ_GERACAO { get; set; }
        public string VGFOLLOW_NUM_FITA_CEF { get; set; }
        public string VGFOLLOW_NUM_NOSSA_FITA { get; set; }
        public string VGFOLLOW_NUM_LANCAMENTO { get; set; }
        public string VGFOLLOW_COD_CONVENIO { get; set; }
        public string VGFOLLOW_NUM_CERTIFICADO { get; set; }
        public string VGFOLLOW_COD_BANCO { get; set; }
        public string VGFOLLOW_STA_PROCESSAMENTO { get; set; }
        public string VGFOLLOW_NUM_VERSAO_LAYOUT { get; set; }
        public string VGFOLLOW_REG_LANCAMENTO { get; set; }
        public string VGFOLLOW_COD_USUARIO { get; set; }

        public static void Execute(R0020_00_PROCESSA_DB_INSERT_1_Insert1 r0020_00_PROCESSA_DB_INSERT_1_Insert1)
        {
            var ths = r0020_00_PROCESSA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0020_00_PROCESSA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}