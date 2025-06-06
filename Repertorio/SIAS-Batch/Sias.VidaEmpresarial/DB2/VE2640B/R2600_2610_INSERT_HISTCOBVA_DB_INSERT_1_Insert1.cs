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
    public class R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 : QueryBasis<R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL
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
            :PROPOVA-DATA-VENCIMENTO,
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
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COBER_HIST_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.COBHISVI_NUM_TITULO)}, {FieldThreatment(this.PROPOVA_DATA_VENCIMENTO)}, {FieldThreatment(this.COBHISVI_PRM_TOTAL)}, {FieldThreatment(this.PARCEVID_OPCAO_PAGAMENTO)}, {FieldThreatment(this.COBHISVI_SIT_REGISTRO)}, 0, {FieldThreatment(this.COBHISVI_OCORR_HISTORICO)}, 0, {FieldThreatment(this.COBHISVI_BCO_AVISO)} , {FieldThreatment(this.COBHISVI_AGE_AVISO)} , {FieldThreatment(this.COBHISVI_NUM_AVISO_CREDITO)}, 0)";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string PARCEVID_OPCAO_PAGAMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string COBHISVI_BCO_AVISO { get; set; }
        public string COBHISVI_AGE_AVISO { get; set; }
        public string COBHISVI_NUM_AVISO_CREDITO { get; set; }

        public static void Execute(R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 r2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1)
        {
            var ths = r2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}