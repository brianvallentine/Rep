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
    public class DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            ( CODUSU
            , DATA_SOLICITACAO
            , IDSISTEM
            , CODRELAT
            , NRCOPIAS
            , QUANTIDADE
            , PERI_INICIAL
            , PERI_FINAL
            , DATA_REFERENCIA
            , MES_REFERENCIA
            , ANO_REFERENCIA
            , ORGAO
            , FONTE
            , CODPDT
            , RAMO
            , MODALIDA
            , CONGENER
            , NUM_APOLICE
            , NRENDOS
            , NRPARCEL
            , NRCERTIF
            , NRTIT
            , CODSUBES
            , OPERACAO
            , COD_PLANO
            , OCORHIST
            , APOLIDER
            , ENDOSLID
            , NUM_PARC_LIDER
            , NUM_SINISTRO
            , NUM_SINI_LIDER
            , NUM_ORDEM
            , CODUNIMO
            , CORRECAO
            , SITUACAO
            , PREVIA_DEFINITIVA
            , ANAL_RESUMO
            , COD_EMPRESA
            , PERI_RENOVACAO
            , PCT_AUMENTO
            , TIMESTAMP
            )
            VALUES ( 'VE2640B' ,
            :H-DT-MOV-ABERTO-2600 ,
            'VL' ,
            :H-COD-RELATORIO,
            0,
            0,
            :H-DT-MOV-ABERTO-2600 ,
            :H-DT-MOV-ABERTO-2600 ,
            :H-DT-MOV-ABERTO-2600 ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :VGPROSIA-NUM-APOLICE ,
            0,
            0,
            :VGCOMTRO-NUM-PROPOSTA-SIVPF,
            :TERMOADE-NUM-TERMO,
            :SUBGVGAP-COD-SUBGRUPO ,
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
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS ( CODUSU , DATA_SOLICITACAO , IDSISTEM , CODRELAT , NRCOPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO , FONTE , CODPDT , RAMO , MODALIDA , CONGENER , NUM_APOLICE , NRENDOS , NRPARCEL , NRCERTIF , NRTIT , CODSUBES , OPERACAO , COD_PLANO , OCORHIST , APOLIDER , ENDOSLID , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , CODUNIMO , CORRECAO , SITUACAO , PREVIA_DEFINITIVA , ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( 'VE2640B' , {FieldThreatment(this.H_DT_MOV_ABERTO_2600)} , 'VL' , {FieldThreatment(this.H_COD_RELATORIO)}, 0, 0, {FieldThreatment(this.H_DT_MOV_ABERTO_2600)} , {FieldThreatment(this.H_DT_MOV_ABERTO_2600)} , {FieldThreatment(this.H_DT_MOV_ABERTO_2600)} , 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.VGPROSIA_NUM_APOLICE)} , 0, 0, {FieldThreatment(this.VGCOMTRO_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.TERMOADE_NUM_TERMO)}, {FieldThreatment(this.SUBGVGAP_COD_SUBGRUPO)} , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string H_DT_MOV_ABERTO_2600 { get; set; }
        public string H_COD_RELATORIO { get; set; }
        public string VGPROSIA_NUM_APOLICE { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }

        public static void Execute(DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1 dB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = dB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB072_INCLUI_V0RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}