using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1 : QueryBasis<R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET SIT_REGISTRO =  '{this.HOST_SIT_REGISTRO}'
				WHERE  COD_EMPRESA =  '{this.MOVIMCOB_COD_EMPRESA}'
				AND COD_MOVIMENTO =  '{this.MOVIMCOB_COD_MOVIMENTO}'
				AND COD_BANCO =  '{this.MOVIMCOB_COD_BANCO}'
				AND COD_AGENCIA =  '{this.MOVIMCOB_COD_AGENCIA}'
				AND NUM_AVISO =  '{this.MOVIMCOB_NUM_AVISO}'
				AND NUM_FITA =  '{this.MOVIMCOB_NUM_FITA}'
				AND DATA_MOVIMENTO =  '{this.MOVIMCOB_DATA_MOVIMENTO}'
				AND DATA_QUITACAO =  '{this.MOVIMCOB_DATA_QUITACAO}'
				AND NUM_TITULO =  '{this.MOVIMCOB_NUM_TITULO}'
				AND NUM_APOLICE =  '{this.MOVIMCOB_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.MOVIMCOB_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.MOVIMCOB_NUM_PARCELA}'
				AND TIPO_MOVIMENTO =  '{this.MOVIMCOB_TIPO_MOVIMENTO}'
				AND NUM_NOSSO_TITULO =  '{this.MOVIMCOB_NUM_NOSSO_TITULO}'";

            return query;
        }
        public string HOST_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string MOVIMCOB_DATA_MOVIMENTO { get; set; }
        public string MOVIMCOB_TIPO_MOVIMENTO { get; set; }
        public string MOVIMCOB_COD_MOVIMENTO { get; set; }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string MOVIMCOB_COD_EMPRESA { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_FITA { get; set; }

        public static void Execute(R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1 r1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1)
        {
            var ths = r1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}