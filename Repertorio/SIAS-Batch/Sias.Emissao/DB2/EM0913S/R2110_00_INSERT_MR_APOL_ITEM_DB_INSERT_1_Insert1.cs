using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0913S
{
    public class R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1 : QueryBasis<R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MR_APOLICE_ITEM
            (NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_ITEM,
            COD_PRODUTO,
            NUM_VERSAO,
            NUM_TP_MORA_IMOVEL,
            NUM_TP_OCUP_IMOVEL,
            DTH_INI_VIG_ITEM,
            DTH_FIM_VIG_ITEM,
            QTD_RENOVACAO,
            OCORR_ENDERECO,
            STA_PROP_ITEM,
            PCT_DESC_FIDEL,
            PCT_DESC_AGRUP,
            PCT_DESC_EXPER,
            DTH_TIMESTAMP,
            COD_CLIENTE ,
            COD_BENEFICIARIO,
            IND_RENOVACAO_AUT,
            NUM_PROPOSTA_SIMU)
            VALUES (:MRAPOITE-NUM-APOLICE,
            :MRAPOITE-NUM-ENDOSSO,
            :MRAPOITE-NUM-ITEM,
            :MRAPOITE-COD-PRODUTO,
            :MRAPOITE-NUM-VERSAO,
            :MRAPOITE-NUM-TP-MORA-IMOVEL,
            :MRAPOITE-NUM-TP-OCUP-IMOVEL,
            :MRAPOITE-DTH-INI-VIG-ITEM,
            :MRAPOITE-DTH-FIM-VIG-ITEM,
            :MRAPOITE-QTD-RENOVACAO,
            :MRAPOITE-OCORR-ENDERECO,
            :MRAPOITE-STA-PROP-ITEM,
            :MRAPOITE-PCT-DESC-FIDEL,
            :MRAPOITE-PCT-DESC-AGRUP,
            :MRAPOITE-PCT-DESC-EXPER,
            CURRENT TIMESTAMP,
            :MRAPOITE-COD-CLIENTE ,
            :MRAPOITE-COD-BENEFICIARIO :WNULL-COD-BENEF,
            :MRAPOITE-IND-RENOVACAO-AUT,
            :MRAPOITE-NUM-PROPOSTA-SIMU :WNULL-PROPOSTA-SIMU)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MR_APOLICE_ITEM (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_PRODUTO, NUM_VERSAO, NUM_TP_MORA_IMOVEL, NUM_TP_OCUP_IMOVEL, DTH_INI_VIG_ITEM, DTH_FIM_VIG_ITEM, QTD_RENOVACAO, OCORR_ENDERECO, STA_PROP_ITEM, PCT_DESC_FIDEL, PCT_DESC_AGRUP, PCT_DESC_EXPER, DTH_TIMESTAMP, COD_CLIENTE , COD_BENEFICIARIO, IND_RENOVACAO_AUT, NUM_PROPOSTA_SIMU) VALUES ({FieldThreatment(this.MRAPOITE_NUM_APOLICE)}, {FieldThreatment(this.MRAPOITE_NUM_ENDOSSO)}, {FieldThreatment(this.MRAPOITE_NUM_ITEM)}, {FieldThreatment(this.MRAPOITE_COD_PRODUTO)}, {FieldThreatment(this.MRAPOITE_NUM_VERSAO)}, {FieldThreatment(this.MRAPOITE_NUM_TP_MORA_IMOVEL)}, {FieldThreatment(this.MRAPOITE_NUM_TP_OCUP_IMOVEL)}, {FieldThreatment(this.MRAPOITE_DTH_INI_VIG_ITEM)}, {FieldThreatment(this.MRAPOITE_DTH_FIM_VIG_ITEM)}, {FieldThreatment(this.MRAPOITE_QTD_RENOVACAO)}, {FieldThreatment(this.MRAPOITE_OCORR_ENDERECO)}, {FieldThreatment(this.MRAPOITE_STA_PROP_ITEM)}, {FieldThreatment(this.MRAPOITE_PCT_DESC_FIDEL)}, {FieldThreatment(this.MRAPOITE_PCT_DESC_AGRUP)}, {FieldThreatment(this.MRAPOITE_PCT_DESC_EXPER)}, CURRENT TIMESTAMP, {FieldThreatment(this.MRAPOITE_COD_CLIENTE)} ,  {FieldThreatment((this.WNULL_COD_BENEF?.ToInt() == -1 ? null : this.MRAPOITE_COD_BENEFICIARIO))}, {FieldThreatment(this.MRAPOITE_IND_RENOVACAO_AUT)},  {FieldThreatment((this.WNULL_PROPOSTA_SIMU?.ToInt() == -1 ? null : this.MRAPOITE_NUM_PROPOSTA_SIMU))})";

            return query;
        }
        public string MRAPOITE_NUM_APOLICE { get; set; }
        public string MRAPOITE_NUM_ENDOSSO { get; set; }
        public string MRAPOITE_NUM_ITEM { get; set; }
        public string MRAPOITE_COD_PRODUTO { get; set; }
        public string MRAPOITE_NUM_VERSAO { get; set; }
        public string MRAPOITE_NUM_TP_MORA_IMOVEL { get; set; }
        public string MRAPOITE_NUM_TP_OCUP_IMOVEL { get; set; }
        public string MRAPOITE_DTH_INI_VIG_ITEM { get; set; }
        public string MRAPOITE_DTH_FIM_VIG_ITEM { get; set; }
        public string MRAPOITE_QTD_RENOVACAO { get; set; }
        public string MRAPOITE_OCORR_ENDERECO { get; set; }
        public string MRAPOITE_STA_PROP_ITEM { get; set; }
        public string MRAPOITE_PCT_DESC_FIDEL { get; set; }
        public string MRAPOITE_PCT_DESC_AGRUP { get; set; }
        public string MRAPOITE_PCT_DESC_EXPER { get; set; }
        public string MRAPOITE_COD_CLIENTE { get; set; }
        public string MRAPOITE_COD_BENEFICIARIO { get; set; }
        public string WNULL_COD_BENEF { get; set; }
        public string MRAPOITE_IND_RENOVACAO_AUT { get; set; }
        public string MRAPOITE_NUM_PROPOSTA_SIMU { get; set; }
        public string WNULL_PROPOSTA_SIMU { get; set; }

        public static void Execute(R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1 r2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1)
        {
            var ths = r2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}