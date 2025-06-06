using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1 : QueryBasis<R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.AU_APOLICE_COMPL
            VALUES (:AU084-NUM-APOLICE ,
            :AU084-NUM-ENDOSSO ,
            :AU084-NUM-ITEM ,
            :AU084-COD-PARCEIRO:VIND-PARC ,
            :AU084-COD-PONTO-VENDA:VIND-PTOV,
            :AU084-NUM-CPF-OPERADOR ,
            :AU084-STA-RENOVACAO-AUT,
            :AU084-STA-ENVIO-SMS ,
            :AU084-STA-ENVIO-EMAIL ,
            :AU084-NUM-TOKEN-PGTO:VIND-TOKEN ,
            :AU084-IND-FORMA-PAGTO-AD)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AU_APOLICE_COMPL VALUES ({FieldThreatment(this.AU084_NUM_APOLICE)} , {FieldThreatment(this.AU084_NUM_ENDOSSO)} , {FieldThreatment(this.AU084_NUM_ITEM)} ,  {FieldThreatment((this.VIND_PARC?.ToInt() == -1 ? null : this.AU084_COD_PARCEIRO))} ,  {FieldThreatment((this.VIND_PTOV?.ToInt() == -1 ? null : this.AU084_COD_PONTO_VENDA))}, {FieldThreatment(this.AU084_NUM_CPF_OPERADOR)} , {FieldThreatment(this.AU084_STA_RENOVACAO_AUT)}, {FieldThreatment(this.AU084_STA_ENVIO_SMS)} , {FieldThreatment(this.AU084_STA_ENVIO_EMAIL)} ,  {FieldThreatment((this.VIND_TOKEN?.ToInt() == -1 ? null : this.AU084_NUM_TOKEN_PGTO))} , {FieldThreatment(this.AU084_IND_FORMA_PAGTO_AD)})";

            return query;
        }
        public string AU084_NUM_APOLICE { get; set; }
        public string AU084_NUM_ENDOSSO { get; set; }
        public string AU084_NUM_ITEM { get; set; }
        public string AU084_COD_PARCEIRO { get; set; }
        public string VIND_PARC { get; set; }
        public string AU084_COD_PONTO_VENDA { get; set; }
        public string VIND_PTOV { get; set; }
        public string AU084_NUM_CPF_OPERADOR { get; set; }
        public string AU084_STA_RENOVACAO_AUT { get; set; }
        public string AU084_STA_ENVIO_SMS { get; set; }
        public string AU084_STA_ENVIO_EMAIL { get; set; }
        public string AU084_NUM_TOKEN_PGTO { get; set; }
        public string VIND_TOKEN { get; set; }
        public string AU084_IND_FORMA_PAGTO_AD { get; set; }

        public static void Execute(R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1 r2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1)
        {
            var ths = r2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}