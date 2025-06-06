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
    public class R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            (
            COD_USUARIO
            , DATA_SOLICITACAO
            , IDE_SISTEMA
            , COD_RELATORIO
            , NUM_COPIAS
            , QUANTIDADE
            , PERI_INICIAL
            , PERI_FINAL
            , DATA_REFERENCIA
            , MES_REFERENCIA
            , ANO_REFERENCIA
            , ORGAO_EMISSOR
            , COD_FONTE
            , COD_PRODUTOR
            , RAMO_EMISSOR
            , COD_MODALIDADE
            , COD_CONGENERE
            , NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , NUM_CERTIFICADO
            , NUM_TITULO
            , COD_SUBGRUPO
            , COD_OPERACAO
            , COD_PLANO
            , OCORR_HISTORICO
            , NUM_APOL_LIDER
            , ENDOS_LIDER
            , NUM_PARC_LIDER
            , NUM_SINISTRO
            , NUM_SINI_LIDER
            , NUM_ORDEM
            , COD_MOEDA
            , TIPO_CORRECAO
            , SIT_REGISTRO
            , IND_PREV_DEFINIT
            , IND_ANAL_RESUMO
            , COD_EMPRESA
            , PERI_RENOVACAO
            , PCT_AUMENTO
            ,TIMESTAMP
            )
            VALUES ( 'VA0601B' ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            'VA' ,
            'VA0469B' ,
            :RELATORI-NUM-COPIAS,
            :WHOST-BCO-RELAT,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB,
            0,
            0,
            0,
            0,
            0,
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE,
            0,
            1,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            0,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO,
            16,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB,
            ' ' ,
            :WHOST-SIN-RELAT,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO ,TIMESTAMP ) VALUES ( 'VA0601B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'VA' , 'VA0469B' , {FieldThreatment(this.RELATORI_NUM_COPIAS)}, {FieldThreatment(this.WHOST_BCO_RELAT)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.PROPOFID_AGECTADEB)}, {FieldThreatment(this.PROPOFID_OPRCTADEB)}, {FieldThreatment(this.PROPOFID_DIGCTADEB)}, 0, 0, 0, 0, 0, {FieldThreatment(this.PROPSSVD_NUM_APOLICE)}, 0, 1, {FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, 0, {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)}, 16, 0, 0, ' ' , ' ' , 0, {FieldThreatment(this.PROPOFID_NUMCTADEB)}, ' ' , {FieldThreatment(this.WHOST_SIN_RELAT)}, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string WHOST_BCO_RELAT { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string WHOST_SIN_RELAT { get; set; }

        public static void Execute(R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}