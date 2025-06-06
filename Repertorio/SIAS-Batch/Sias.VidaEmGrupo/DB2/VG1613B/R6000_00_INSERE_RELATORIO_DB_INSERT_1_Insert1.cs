using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            (COD_USUARIO,
            DATA_SOLICITACAO,
            IDE_SISTEMA,
            COD_RELATORIO,
            NUM_COPIAS,
            QUANTIDADE,
            PERI_INICIAL,
            PERI_FINAL,
            DATA_REFERENCIA,
            MES_REFERENCIA,
            ANO_REFERENCIA,
            ORGAO_EMISSOR,
            COD_FONTE,
            COD_PRODUTOR,
            RAMO_EMISSOR,
            COD_MODALIDADE,
            COD_CONGENERE,
            NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            NUM_CERTIFICADO,
            NUM_TITULO,
            COD_SUBGRUPO,
            COD_OPERACAO,
            COD_PLANO,
            OCORR_HISTORICO,
            NUM_APOL_LIDER,
            ENDOS_LIDER,
            NUM_PARC_LIDER,
            NUM_SINISTRO,
            NUM_SINI_LIDER,
            NUM_ORDEM,
            COD_MOEDA,
            TIPO_CORRECAO,
            SIT_REGISTRO,
            IND_PREV_DEFINIT,
            IND_ANAL_RESUMO,
            COD_EMPRESA,
            PERI_RENOVACAO,
            PCT_AUMENTO,
            TIMESTAMP)
            VALUES ( 'VG1613B' ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            'VA' ,
            'VG1626B' ,
            0,
            0,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :RELATORI-NUM-APOLICE,
            0,
            0,
            0,
            0,
            :RELATORI-COD-SUBGRUPO ,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '1' ,
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
				INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) VALUES ( 'VG1613B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 'VA' , 'VG1626B' , 0, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.RELATORI_NUM_APOLICE)}, 0, 0, 0, 0, {FieldThreatment(this.RELATORI_COD_SUBGRUPO)} , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '1' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }

        public static void Execute(R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1 r6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = r6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}