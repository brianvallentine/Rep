using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1 : QueryBasis<R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.COBER_HIST_VIDAZUL
            SELECT
            NUM_CERTIFICADO ,
            :PARCEVID-NUM-PARCELA1 NUM_PARCELA ,
            :WHOST-NRTITULO NUM_TITULO ,
            :PROPOVA-DTPROXVEN DATA_VENCIMENTO ,
            :PLAVAVGA-VLPREMIOTOT PRM_TOTAL ,
            :OPCPAGVI-OPCAO-PAGAMENTO OPCAO_PAGAMENTO ,
            :COBHISVI-SIT-REGISTRO SIT_REGISTRO ,
            0 COD_OPERACAO ,
            0 OCORR_HISTORICO ,
            0 COD_DEVOLUCAO ,
            0 BCO_AVISO ,
            0 AGE_AVISO ,
            0 NUM_AVISO_CREDITO ,
            0 NUM_TITULO_COMP
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :PARCEVID-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COBER_HIST_VIDAZUL SELECT NUM_CERTIFICADO , {FieldThreatment(this.PARCEVID_NUM_PARCELA1)} NUM_PARCELA , {FieldThreatment(this.WHOST_NRTITULO)} NUM_TITULO , {FieldThreatment(this.PROPOVA_DTPROXVEN)} DATA_VENCIMENTO , {FieldThreatment(this.PLAVAVGA_VLPREMIOTOT)} PRM_TOTAL , {FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)} OPCAO_PAGAMENTO , {FieldThreatment(this.COBHISVI_SIT_REGISTRO)} SIT_REGISTRO , 0 COD_OPERACAO , 0 OCORR_HISTORICO , 0 COD_DEVOLUCAO , 0 BCO_AVISO , 0 AGE_AVISO , 0 NUM_AVISO_CREDITO , 0 NUM_TITULO_COMP FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)} AND NUM_PARCELA = {FieldThreatment(this.PARCEVID_NUM_PARCELA)}";

            return query;
        }
        public string PARCEVID_NUM_PARCELA1 { get; set; }
        public string WHOST_NRTITULO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static void Execute(R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1 r1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1)
        {
            var ths = r1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}