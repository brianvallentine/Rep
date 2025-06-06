using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1 : QueryBasis<M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SEGURADOS_VGAP
            VALUES (:PROPVA-NUM-APOLICE,
            :PROPVA-CODSUBES,
            :PROPVA-NRCERTIF,
            ' ' ,
            '1' ,
            :APOLICES-NUM-ITEM,
            '4' ,
            :PROPVA-CODCLIEN,
            :PROPVA-FONTE,
            :PROPVA-NRPROPOS,
            0,
            0,
            0,
            0,
            1,
            'S' ,
            'S' ,
            :SEGURVGA-OCORR-HISTORICO,
            :OPCAOP-PERIPGTO,
            :SUBGVGAP-PERI-RENOVACAO,
            0,
            ' ' ,
            ' ' ,
            :SEGURVGA-IDE-SEXO,
            0,
            ' ' ,
            :PROPVA-OCOREND,
            :PROPVA-OCOREND,
            0,
            0,
            '0' ,
            0,
            0,
            '0' ,
            :SUBGVGAP-TIPO-PLANO,
            :PROPVA-DTQITBCO,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            '0' ,
            CURRENT DATE,
            :SEGURVGA-DATA-NASCIMENTO,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SEGURADOS_VGAP VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, ' ' , '1' , {FieldThreatment(this.APOLICES_NUM_ITEM)}, '4' , {FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.PROPVA_NRPROPOS)}, 0, 0, 0, 0, 1, 'S' , 'S' , {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO)}, {FieldThreatment(this.OPCAOP_PERIPGTO)}, {FieldThreatment(this.SUBGVGAP_PERI_RENOVACAO)}, 0, ' ' , ' ' , {FieldThreatment(this.SEGURVGA_IDE_SEXO)}, 0, ' ' , {FieldThreatment(this.PROPVA_OCOREND)}, {FieldThreatment(this.PROPVA_OCOREND)}, 0, 0, '0' , 0, 0, '0' , {FieldThreatment(this.SUBGVGAP_TIPO_PLANO)}, {FieldThreatment(this.PROPVA_DTQITBCO)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '0' , CURRENT DATE, {FieldThreatment(this.SEGURVGA_DATA_NASCIMENTO)}, NULL, NULL, NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string APOLICES_NUM_ITEM { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_NRPROPOS { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string SUBGVGAP_PERI_RENOVACAO { get; set; }
        public string SEGURVGA_IDE_SEXO { get; set; }
        public string PROPVA_OCOREND { get; set; }
        public string SUBGVGAP_TIPO_PLANO { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string SEGURVGA_DATA_NASCIMENTO { get; set; }

        public static void Execute(M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1 m_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1)
        {
            var ths = m_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}