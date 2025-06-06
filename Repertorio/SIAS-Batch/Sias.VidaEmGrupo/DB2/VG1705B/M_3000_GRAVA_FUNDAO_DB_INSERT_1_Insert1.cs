using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1 : QueryBasis<M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.FUNDO_COMISSAO_VA
            (CODIGO_PRODUTO ,
            NUM_CERTIFICADO ,
            NUM_PROPOSTA_AZUL ,
            NUM_TERMO ,
            SITUACAO ,
            COD_OPERACAO ,
            COD_FONTE ,
            COD_AGENCIA ,
            COD_CLIENTE ,
            NUM_MATRI_VENDEDOR ,
            VAL_BASICO_VG ,
            VAL_BASICO_AP ,
            VAL_COMISSAO_VG ,
            VAL_COMISSAO_AP ,
            DATA_QUITACAO ,
            PCCOMIND ,
            PCCOMGER ,
            PCCOMSUP ,
            DATA_MOVIMENTO ,
            COD_USUARIO ,
            TIMESTAMP ,
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            NUM_ENDOSSO ,
            NUM_TITULO )
            VALUES (:FUNCOMVA-CODIGO-PRODUTO ,
            :FUNCOMVA-NUM-CERTIFICADO ,
            :FUNCOMVA-NUM-PROPOSTA-AZUL ,
            :FUNCOMVA-NUM-TERMO ,
            :FUNCOMVA-SITUACAO ,
            :FUNCOMVA-COD-OPERACAO ,
            :FUNCOMVA-COD-FONTE ,
            :FUNCOMVA-COD-AGENCIA ,
            :FUNCOMVA-COD-CLIENTE ,
            :FUNCOMVA-NUM-MATRI-VENDEDOR ,
            :FUNCOMVA-VAL-BASICO-VG ,
            :FUNCOMVA-VAL-BASICO-AP ,
            :FUNCOMVA-VAL-COMISSAO-VG ,
            :FUNCOMVA-VAL-COMISSAO-AP ,
            :FUNCOMVA-DATA-QUITACAO ,
            :FUNCOMVA-PCCOMIND ,
            :FUNCOMVA-PCCOMGER ,
            :FUNCOMVA-PCCOMSUP ,
            :FUNCOMVA-DATA-MOVIMENTO ,
            :FUNCOMVA-COD-USUARIO ,
            CURRENT TIMESTAMP ,
            :FUNCOMVA-NUM-APOLICE ,
            :FUNCOMVA-COD-SUBGRUPO ,
            :FUNCOMVA-NUM-ENDOSSO ,
            :FUNCOMVA-NUM-TITULO )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FUNDO_COMISSAO_VA (CODIGO_PRODUTO , NUM_CERTIFICADO , NUM_PROPOSTA_AZUL , NUM_TERMO , SITUACAO , COD_OPERACAO , COD_FONTE , COD_AGENCIA , COD_CLIENTE , NUM_MATRI_VENDEDOR , VAL_BASICO_VG , VAL_BASICO_AP , VAL_COMISSAO_VG , VAL_COMISSAO_AP , DATA_QUITACAO , PCCOMIND , PCCOMGER , PCCOMSUP , DATA_MOVIMENTO , COD_USUARIO , TIMESTAMP , NUM_APOLICE , COD_SUBGRUPO , NUM_ENDOSSO , NUM_TITULO ) VALUES ({FieldThreatment(this.FUNCOMVA_CODIGO_PRODUTO)} , {FieldThreatment(this.FUNCOMVA_NUM_CERTIFICADO)} , {FieldThreatment(this.FUNCOMVA_NUM_PROPOSTA_AZUL)} , {FieldThreatment(this.FUNCOMVA_NUM_TERMO)} , {FieldThreatment(this.FUNCOMVA_SITUACAO)} , {FieldThreatment(this.FUNCOMVA_COD_OPERACAO)} , {FieldThreatment(this.FUNCOMVA_COD_FONTE)} , {FieldThreatment(this.FUNCOMVA_COD_AGENCIA)} , {FieldThreatment(this.FUNCOMVA_COD_CLIENTE)} , {FieldThreatment(this.FUNCOMVA_NUM_MATRI_VENDEDOR)} , {FieldThreatment(this.FUNCOMVA_VAL_BASICO_VG)} , {FieldThreatment(this.FUNCOMVA_VAL_BASICO_AP)} , {FieldThreatment(this.FUNCOMVA_VAL_COMISSAO_VG)} , {FieldThreatment(this.FUNCOMVA_VAL_COMISSAO_AP)} , {FieldThreatment(this.FUNCOMVA_DATA_QUITACAO)} , {FieldThreatment(this.FUNCOMVA_PCCOMIND)} , {FieldThreatment(this.FUNCOMVA_PCCOMGER)} , {FieldThreatment(this.FUNCOMVA_PCCOMSUP)} , {FieldThreatment(this.FUNCOMVA_DATA_MOVIMENTO)} , {FieldThreatment(this.FUNCOMVA_COD_USUARIO)} , CURRENT TIMESTAMP , {FieldThreatment(this.FUNCOMVA_NUM_APOLICE)} , {FieldThreatment(this.FUNCOMVA_COD_SUBGRUPO)} , {FieldThreatment(this.FUNCOMVA_NUM_ENDOSSO)} , {FieldThreatment(this.FUNCOMVA_NUM_TITULO)} )";

            return query;
        }
        public string FUNCOMVA_CODIGO_PRODUTO { get; set; }
        public string FUNCOMVA_NUM_CERTIFICADO { get; set; }
        public string FUNCOMVA_NUM_PROPOSTA_AZUL { get; set; }
        public string FUNCOMVA_NUM_TERMO { get; set; }
        public string FUNCOMVA_SITUACAO { get; set; }
        public string FUNCOMVA_COD_OPERACAO { get; set; }
        public string FUNCOMVA_COD_FONTE { get; set; }
        public string FUNCOMVA_COD_AGENCIA { get; set; }
        public string FUNCOMVA_COD_CLIENTE { get; set; }
        public string FUNCOMVA_NUM_MATRI_VENDEDOR { get; set; }
        public string FUNCOMVA_VAL_BASICO_VG { get; set; }
        public string FUNCOMVA_VAL_BASICO_AP { get; set; }
        public string FUNCOMVA_VAL_COMISSAO_VG { get; set; }
        public string FUNCOMVA_VAL_COMISSAO_AP { get; set; }
        public string FUNCOMVA_DATA_QUITACAO { get; set; }
        public string FUNCOMVA_PCCOMIND { get; set; }
        public string FUNCOMVA_PCCOMGER { get; set; }
        public string FUNCOMVA_PCCOMSUP { get; set; }
        public string FUNCOMVA_DATA_MOVIMENTO { get; set; }
        public string FUNCOMVA_COD_USUARIO { get; set; }
        public string FUNCOMVA_NUM_APOLICE { get; set; }
        public string FUNCOMVA_COD_SUBGRUPO { get; set; }
        public string FUNCOMVA_NUM_ENDOSSO { get; set; }
        public string FUNCOMVA_NUM_TITULO { get; set; }

        public static void Execute(M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1 m_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1)
        {
            var ths = m_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}