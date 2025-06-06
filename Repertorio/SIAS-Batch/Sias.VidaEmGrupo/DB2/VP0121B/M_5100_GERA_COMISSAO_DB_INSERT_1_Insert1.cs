using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1 : QueryBasis<M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COMISSOES
            VALUES( :COMISSOE-NUM-APOLICE,
            :COMISSOE-NUM-ENDOSSO,
            :COMISSOE-NUM-CERTIFICADO,
            :COMISSOE-DAC-CERTIFICADO,
            :COMISSOE-TIPO-SEGURADO,
            :COMISSOE-NUM-PARCELA,
            :COMISSOE-COD-OPERACAO,
            :COMISSOE-COD-PRODUTOR,
            :COMISSOE-RAMO-COBERTURA,
            :COMISSOE-MODALI-COBERTURA,
            :COMISSOE-OCORR-HISTORICO,
            :COMISSOE-COD-FONTE,
            :COMISSOE-COD-CLIENTE,
            :COMISSOE-VAL-COMISSAO,
            :COMISSOE-DATA-CALCULO,
            :COMISSOE-NUM-RECIBO,
            :COMISSOE-VAL-BASICO,
            :COMISSOE-TIPO-COMISSAO,
            :COMISSOE-QTD-PARCELAS,
            :COMISSOE-PCT-COM-CORRETOR,
            :COMISSOE-PCT-DESC-PREMIO,
            :COMISSOE-COD-SUBGRUPO,
            CURRENT TIME,
            :COMISSOE-DATA-MOVIMENTO:VIND-DTMOVTO,
            :COMISSOE-DATA-SELECAO:VIND-DATSEL,
            :COMISSOE-COD-EMPRESA:VIND-CODEMP,
            :COMISSOE-COD-PREPOSTO:VIND-CODPRP,
            CURRENT TIMESTAMP,
            :COMISSOE-NUM-BILHETE:VIND-NUMBIL,
            :COMISSOE-VAL-VARMON:VIND-VLVARMON,
            :COMISSOE-DATA-QUITACAO:VIND-DTQITBCO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMISSOES VALUES( {FieldThreatment(this.COMISSOE_NUM_APOLICE)}, {FieldThreatment(this.COMISSOE_NUM_ENDOSSO)}, {FieldThreatment(this.COMISSOE_NUM_CERTIFICADO)}, {FieldThreatment(this.COMISSOE_DAC_CERTIFICADO)}, {FieldThreatment(this.COMISSOE_TIPO_SEGURADO)}, {FieldThreatment(this.COMISSOE_NUM_PARCELA)}, {FieldThreatment(this.COMISSOE_COD_OPERACAO)}, {FieldThreatment(this.COMISSOE_COD_PRODUTOR)}, {FieldThreatment(this.COMISSOE_RAMO_COBERTURA)}, {FieldThreatment(this.COMISSOE_MODALI_COBERTURA)}, {FieldThreatment(this.COMISSOE_OCORR_HISTORICO)}, {FieldThreatment(this.COMISSOE_COD_FONTE)}, {FieldThreatment(this.COMISSOE_COD_CLIENTE)}, {FieldThreatment(this.COMISSOE_VAL_COMISSAO)}, {FieldThreatment(this.COMISSOE_DATA_CALCULO)}, {FieldThreatment(this.COMISSOE_NUM_RECIBO)}, {FieldThreatment(this.COMISSOE_VAL_BASICO)}, {FieldThreatment(this.COMISSOE_TIPO_COMISSAO)}, {FieldThreatment(this.COMISSOE_QTD_PARCELAS)}, {FieldThreatment(this.COMISSOE_PCT_COM_CORRETOR)}, {FieldThreatment(this.COMISSOE_PCT_DESC_PREMIO)}, {FieldThreatment(this.COMISSOE_COD_SUBGRUPO)}, CURRENT TIME,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.COMISSOE_DATA_MOVIMENTO))},  {FieldThreatment((this.VIND_DATSEL?.ToInt() == -1 ? null : this.COMISSOE_DATA_SELECAO))},  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.COMISSOE_COD_EMPRESA))},  {FieldThreatment((this.VIND_CODPRP?.ToInt() == -1 ? null : this.COMISSOE_COD_PREPOSTO))}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_NUMBIL?.ToInt() == -1 ? null : this.COMISSOE_NUM_BILHETE))},  {FieldThreatment((this.VIND_VLVARMON?.ToInt() == -1 ? null : this.COMISSOE_VAL_VARMON))},  {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.COMISSOE_DATA_QUITACAO))})";

            return query;
        }
        public string COMISSOE_NUM_APOLICE { get; set; }
        public string COMISSOE_NUM_ENDOSSO { get; set; }
        public string COMISSOE_NUM_CERTIFICADO { get; set; }
        public string COMISSOE_DAC_CERTIFICADO { get; set; }
        public string COMISSOE_TIPO_SEGURADO { get; set; }
        public string COMISSOE_NUM_PARCELA { get; set; }
        public string COMISSOE_COD_OPERACAO { get; set; }
        public string COMISSOE_COD_PRODUTOR { get; set; }
        public string COMISSOE_RAMO_COBERTURA { get; set; }
        public string COMISSOE_MODALI_COBERTURA { get; set; }
        public string COMISSOE_OCORR_HISTORICO { get; set; }
        public string COMISSOE_COD_FONTE { get; set; }
        public string COMISSOE_COD_CLIENTE { get; set; }
        public string COMISSOE_VAL_COMISSAO { get; set; }
        public string COMISSOE_DATA_CALCULO { get; set; }
        public string COMISSOE_NUM_RECIBO { get; set; }
        public string COMISSOE_VAL_BASICO { get; set; }
        public string COMISSOE_TIPO_COMISSAO { get; set; }
        public string COMISSOE_QTD_PARCELAS { get; set; }
        public string COMISSOE_PCT_COM_CORRETOR { get; set; }
        public string COMISSOE_PCT_DESC_PREMIO { get; set; }
        public string COMISSOE_COD_SUBGRUPO { get; set; }
        public string COMISSOE_DATA_MOVIMENTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string COMISSOE_DATA_SELECAO { get; set; }
        public string VIND_DATSEL { get; set; }
        public string COMISSOE_COD_EMPRESA { get; set; }
        public string VIND_CODEMP { get; set; }
        public string COMISSOE_COD_PREPOSTO { get; set; }
        public string VIND_CODPRP { get; set; }
        public string COMISSOE_NUM_BILHETE { get; set; }
        public string VIND_NUMBIL { get; set; }
        public string COMISSOE_VAL_VARMON { get; set; }
        public string VIND_VLVARMON { get; set; }
        public string COMISSOE_DATA_QUITACAO { get; set; }
        public string VIND_DTQITBCO { get; set; }

        public static void Execute(M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1 m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1)
        {
            var ths = m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}