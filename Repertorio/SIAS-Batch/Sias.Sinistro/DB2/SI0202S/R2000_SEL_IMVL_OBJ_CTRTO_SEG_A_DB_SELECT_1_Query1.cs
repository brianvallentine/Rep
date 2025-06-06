using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202S
{
    public class R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 : QueryBasis<R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DES_ENDERECO || ' ' ||
            VALUE(A.DES_COMPL_ENDERECO, ' ' )
            ,VALUE(A.NOM_BAIRRO, ' ' )
            ,A.NUM_CEP
            ,A.NOM_CIDADE
            ,VALUE(A.COD_UF, ' ' )
            INTO :W-EF083-ENDERECO
            ,:EF083-NOM-BAIRRO
            ,:EF083-NUM-CEP
            ,:EF083-NOM-CIDADE
            ,:EF083-COD-UF
            FROM SEGUROS.EF_IMOVEL A,
            SEGUROS.EF_OBJ_CONTR_SEGUR B
            WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO
            AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
            AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG
            AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG
            AND B.STA_OBJ_CONTR_SEG = 'A'
            AND B.COD_TIPO_OBJ_SEG = 1
            AND A.SEQ_TIPO_OBJ_SEG =
            (SELECT MAX(C.SEQ_TIPO_OBJ_SEG)
            FROM SEGUROS.EF_IMOVEL C,
            SEGUROS.EF_OBJ_CONTR_SEGUR D
            WHERE C.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO
            AND C.NUM_CONTRATO_SEGUR = D.NUM_CONTRATO_SEGUR
            AND C.SEQ_TIPO_OBJ_SEG = D.SEQ_TIPO_OBJ_SEG
            AND C.COD_TIPO_OBJ_SEG = D.COD_TIPO_OBJ_SEG
            AND D.STA_OBJ_CONTR_SEG = 'A'
            AND D.COD_TIPO_OBJ_SEG = 1)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DES_ENDERECO || ' ' ||
											VALUE(A.DES_COMPL_ENDERECO
							, ' ' )
											,VALUE(A.NOM_BAIRRO
							, ' ' )
											,A.NUM_CEP
											,A.NOM_CIDADE
											,VALUE(A.COD_UF
							, ' ' )
											FROM SEGUROS.EF_IMOVEL A
							,
											SEGUROS.EF_OBJ_CONTR_SEGUR B
											WHERE A.NUM_CONTRATO_SEGUR = '{this.EF072_NUM_CONTRATO}'
											AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
											AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG
											AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG
											AND B.STA_OBJ_CONTR_SEG = 'A'
											AND B.COD_TIPO_OBJ_SEG = 1
											AND A.SEQ_TIPO_OBJ_SEG =
											(SELECT MAX(C.SEQ_TIPO_OBJ_SEG)
											FROM SEGUROS.EF_IMOVEL C
							,
											SEGUROS.EF_OBJ_CONTR_SEGUR D
											WHERE C.NUM_CONTRATO_SEGUR = '{this.EF072_NUM_CONTRATO}'
											AND C.NUM_CONTRATO_SEGUR = D.NUM_CONTRATO_SEGUR
											AND C.SEQ_TIPO_OBJ_SEG = D.SEQ_TIPO_OBJ_SEG
											AND C.COD_TIPO_OBJ_SEG = D.COD_TIPO_OBJ_SEG
											AND D.STA_OBJ_CONTR_SEG = 'A'
											AND D.COD_TIPO_OBJ_SEG = 1)
											WITH UR";

            return query;
        }
        public string W_EF083_ENDERECO { get; set; }
        public string EF083_NOM_BAIRRO { get; set; }
        public string EF083_NUM_CEP { get; set; }
        public string EF083_NOM_CIDADE { get; set; }
        public string EF083_COD_UF { get; set; }
        public string EF072_NUM_CONTRATO { get; set; }

        public static R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 Execute(R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 r2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1)
        {
            var ths = r2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_EF083_ENDERECO = result[i++].Value?.ToString();
            dta.EF083_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.EF083_NUM_CEP = result[i++].Value?.ToString();
            dta.EF083_NOM_CIDADE = result[i++].Value?.ToString();
            dta.EF083_COD_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}