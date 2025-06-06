using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            ( COD_USUARIO
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
            , TIMESTAMP
            )
            VALUES
            ( 'VA0118B'
            , :SISTEMA-DTMOVABE
            , 'VA'
            , :RELATO-CODRELAT
            , :RELATO-NUM-COPIAS
            , :WS-BCO-RELAT
            , :SISTEMA-DTMOVABE
            , :SISTEMA-DTMOVABE
            , :SISTEMA-DTMOVABE
            , :PROPOFID-AGECTADEB
            , :PROPOFID-OPRCTADEB
            , :PROPOFID-DIGCTADEB
            , 0
            , 0
            , 0
            , 0
            , 0
            , :PROPVA-NUM-APOLICE
            , 0
            , 1
            , :PROPVA-NRCERTIF
            , 0
            , :PROPVA-CODSUBES
            , 16
            , 0
            , 0
            , ' '
            , ' '
            , 0
            , :PROPOFID-NUMCTADEB
            , ' '
            , :WS-NUM-ORDEM-RELAT
            , 0
            , ' '
            , '0'
            , ' '
            , ' '
            , NULL
            , 0
            , 0
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( 'VA0118B' , {FieldThreatment(this.SISTEMA_DTMOVABE)} , 'VA' , {FieldThreatment(this.RELATO_CODRELAT)} , {FieldThreatment(this.RELATO_NUM_COPIAS)} , {FieldThreatment(this.WS_BCO_RELAT)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , {FieldThreatment(this.PROPOFID_AGECTADEB)} , {FieldThreatment(this.PROPOFID_OPRCTADEB)} , {FieldThreatment(this.PROPOFID_DIGCTADEB)} , 0 , 0 , 0 , 0 , 0 , {FieldThreatment(this.PROPVA_NUM_APOLICE)} , 0 , 1 , {FieldThreatment(this.PROPVA_NRCERTIF)} , 0 , {FieldThreatment(this.PROPVA_CODSUBES)} , 16 , 0 , 0 , ' ' , ' ' , 0 , {FieldThreatment(this.PROPOFID_NUMCTADEB)} , ' ' , {FieldThreatment(this.WS_NUM_ORDEM_RELAT)} , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP )";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string RELATO_CODRELAT { get; set; }
        public string RELATO_NUM_COPIAS { get; set; }
        public string WS_BCO_RELAT { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string WS_NUM_ORDEM_RELAT { get; set; }

        public static void Execute(M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 m_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = m_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0560_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}