using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1 : QueryBasis<DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_COMPL_TERMO
            (NUM_TERMO,
            NUM_PROPOSTA_SIVPF,
            DTH_DIA_DEBITO,
            COD_AGENCIA_DEB,
            OPERACAO_CONTA_DEB,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO,
            DTH_LIBERACAO,
            NUM_CARTAO_CREDITO)
            VALUES
            (:VGCOMTRO-NUM-TERMO,
            :VGCOMTRO-NUM-PROPOSTA-SIVPF,
            :VGCOMTRO-DTH-DIA-DEBITO,
            :VGCOMTRO-COD-AGENCIA-DEB,
            :VGCOMTRO-OPERACAO-CONTA-DEB,
            :VGCOMTRO-NUM-CONTA-DEBITO,
            :VGCOMTRO-DIG-CONTA-DEBITO,
            :VGCOMTRO-DTH-LIBERACAO,
            :VGCOMTRO-NUM-CARTAO-CREDITO)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_COMPL_TERMO (NUM_TERMO, NUM_PROPOSTA_SIVPF, DTH_DIA_DEBITO, COD_AGENCIA_DEB, OPERACAO_CONTA_DEB, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, DTH_LIBERACAO, NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.VGCOMTRO_NUM_TERMO)}, {FieldThreatment(this.VGCOMTRO_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.VGCOMTRO_DTH_DIA_DEBITO)}, {FieldThreatment(this.VGCOMTRO_COD_AGENCIA_DEB)}, {FieldThreatment(this.VGCOMTRO_OPERACAO_CONTA_DEB)}, {FieldThreatment(this.VGCOMTRO_NUM_CONTA_DEBITO)}, {FieldThreatment(this.VGCOMTRO_DIG_CONTA_DEBITO)}, {FieldThreatment(this.VGCOMTRO_DTH_LIBERACAO)}, {FieldThreatment(this.VGCOMTRO_NUM_CARTAO_CREDITO)})";

            return query;
        }
        public string VGCOMTRO_NUM_TERMO { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOMTRO_DTH_DIA_DEBITO { get; set; }
        public string VGCOMTRO_COD_AGENCIA_DEB { get; set; }
        public string VGCOMTRO_OPERACAO_CONTA_DEB { get; set; }
        public string VGCOMTRO_NUM_CONTA_DEBITO { get; set; }
        public string VGCOMTRO_DIG_CONTA_DEBITO { get; set; }
        public string VGCOMTRO_DTH_LIBERACAO { get; set; }
        public string VGCOMTRO_NUM_CARTAO_CREDITO { get; set; }

        public static void Execute(DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1 dB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1)
        {
            var ths = dB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}