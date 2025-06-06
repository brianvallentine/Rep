using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 : QueryBasis<M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COBER_HIST_VIDAZUL
            (NUM_CERTIFICADO ,
            NUM_PARCELA ,
            NUM_TITULO ,
            DATA_VENCIMENTO ,
            PRM_TOTAL ,
            OPCAO_PAGAMENTO ,
            SIT_REGISTRO ,
            COD_OPERACAO ,
            OCORR_HISTORICO ,
            COD_DEVOLUCAO ,
            BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            NUM_TITULO_COMP)
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            :PROPOVA-NUM-PARCELA,
            :COBHISVI-NUM-TITULO,
            :WS-DTVENC-1PARC,
            :COBHISVI-PRM-TOTAL,
            :PARCEVID-OPCAO-PAGAMENTO,
            :COBHISVI-SIT-REGISTRO,
            0,
            :COBHISVI-OCORR-HISTORICO,
            0,
            :COBHISVI-BCO-AVISO ,
            :COBHISVI-AGE-AVISO ,
            :COBHISVI-NUM-AVISO-CREDITO,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COBER_HIST_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.COBHISVI_NUM_TITULO)}, {FieldThreatment(this.WS_DTVENC_1PARC)}, {FieldThreatment(this.COBHISVI_PRM_TOTAL)}, {FieldThreatment(this.PARCEVID_OPCAO_PAGAMENTO)}, {FieldThreatment(this.COBHISVI_SIT_REGISTRO)}, 0, {FieldThreatment(this.COBHISVI_OCORR_HISTORICO)}, 0, {FieldThreatment(this.COBHISVI_BCO_AVISO)} , {FieldThreatment(this.COBHISVI_AGE_AVISO)} , {FieldThreatment(this.COBHISVI_NUM_AVISO_CREDITO)}, 0)";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string WS_DTVENC_1PARC { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string PARCEVID_OPCAO_PAGAMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string COBHISVI_BCO_AVISO { get; set; }
        public string COBHISVI_AGE_AVISO { get; set; }
        public string COBHISVI_NUM_AVISO_CREDITO { get; set; }

        public static void Execute(M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 m_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}