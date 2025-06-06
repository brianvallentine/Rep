using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1 : QueryBasis<M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.CARENCIAS_VGAP
            (NUM_CERTIFICADO,
            OCORR_HISTORICO,
            COD_OPERACAO ,
            IDADE ,
            DATA_MOVIMENTO ,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            SITUACAO ,
            COD_USUARIO ,
            TIMESTAMP )
            VALUES (:MNUM-CERTIFICADO,
            :V0PROP-OCORHIST,
            :MCOD-OPERACAO,
            :V0MLD-IDADE,
            CURRENT DATE,
            :MDATA-REFERENCIA,
            :V0CAR-DTTERVIG,
            '0' ,
            'VG9020S' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CARENCIAS_VGAP (NUM_CERTIFICADO, OCORR_HISTORICO, COD_OPERACAO , IDADE , DATA_MOVIMENTO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, SITUACAO , COD_USUARIO , TIMESTAMP ) VALUES ({FieldThreatment(this.MNUM_CERTIFICADO)}, {FieldThreatment(this.V0PROP_OCORHIST)}, {FieldThreatment(this.MCOD_OPERACAO)}, {FieldThreatment(this.V0MLD_IDADE)}, CURRENT DATE, {FieldThreatment(this.MDATA_REFERENCIA)}, {FieldThreatment(this.V0CAR_DTTERVIG)}, '0' , 'VG9020S' , CURRENT TIMESTAMP)";

            return query;
        }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string V0MLD_IDADE { get; set; }
        public string MDATA_REFERENCIA { get; set; }
        public string V0CAR_DTTERVIG { get; set; }

        public static void Execute(M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1 m_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1)
        {
            var ths = m_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}