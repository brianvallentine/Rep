using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 : QueryBasis<R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COBER_HIST_VIDAZUL
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA,
            :DCLCOBER-HIST-VIDAZUL.NUM-TITULO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO,
            :DCLRCAPS.RCAPS-VAL-RCAP,
            :WHOST-OPCAOPAG,
            :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO,
            :DCLCOBER-HIST-VIDAZUL.COD-OPERACAO,
            :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO,
            :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO,
            :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO,
            :DCLCOBER-HIST-VIDAZUL.NUM-TITULO-COMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COBER_HIST_VIDAZUL VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_PARCELA)}, {FieldThreatment(this.NUM_TITULO)}, {FieldThreatment(this.PROPOFID_DTQITBCO)}, {FieldThreatment(this.RCAPS_VAL_RCAP)}, {FieldThreatment(this.WHOST_OPCAOPAG)}, {FieldThreatment(this.SIT_REGISTRO)}, {FieldThreatment(this.COD_OPERACAO)}, {FieldThreatment(this.OCORR_HISTORICO)}, {FieldThreatment(this.COD_DEVOLUCAO)}, {FieldThreatment(this.RCAPCOMP_BCO_AVISO)}, {FieldThreatment(this.RCAPCOMP_AGE_AVISO)}, {FieldThreatment(this.RCAPCOMP_NUM_AVISO_CREDITO)}, {FieldThreatment(this.NUM_TITULO_COMP)})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_PARCELA { get; set; }
        public string NUM_TITULO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string WHOST_OPCAOPAG { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string COD_OPERACAO { get; set; }
        public string OCORR_HISTORICO { get; set; }
        public string COD_DEVOLUCAO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string NUM_TITULO_COMP { get; set; }

        public static void Execute(R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1)
        {
            var ths = r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}