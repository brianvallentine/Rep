using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 : QueryBasis<R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_CONT_PARCELVA
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA,
            :DCLCOBER-HIST-VIDAZUL.NUM-TITULO,
            :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO,
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO,
            :WHOST-FONTE,
            :DCLHIST-CONT-PARCELVA.NUM-ENDOSSO,
            :DCLRCAPS.RCAPS-VAL-RCAP,
            :DCLHIST-CONT-PARCELVA.PREMIO-AP,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLHIST-CONT-PARCELVA.SIT-REGISTRO,
            :DCLHIST-CONT-PARCELVA.COD-OPERACAO,
            CURRENT TIMESTAMP,
            :DCLHIST-CONT-PARCELVA.DTFATUR:VIND-DTFATUR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_CONT_PARCELVA VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_PARCELA)}, {FieldThreatment(this.NUM_TITULO)}, {FieldThreatment(this.OCORR_HISTORICO)}, {FieldThreatment(this.PROPSSVD_NUM_APOLICE)}, {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)}, {FieldThreatment(this.WHOST_FONTE)}, {FieldThreatment(this.NUM_ENDOSSO)}, {FieldThreatment(this.RCAPS_VAL_RCAP)}, {FieldThreatment(this.PREMIO_AP)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SIT_REGISTRO)}, {FieldThreatment(this.COD_OPERACAO)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTFATUR?.ToInt() == -1 ? null : this.DTFATUR))})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_PARCELA { get; set; }
        public string NUM_TITULO { get; set; }
        public string OCORR_HISTORICO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string WHOST_FONTE { get; set; }
        public string NUM_ENDOSSO { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string PREMIO_AP { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string COD_OPERACAO { get; set; }
        public string DTFATUR { get; set; }
        public string VIND_DTFATUR { get; set; }

        public static void Execute(R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1)
        {
            var ths = r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}